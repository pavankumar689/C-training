using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }

    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }

    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is invalid");

            username = username.Trim();

            email = email.Trim().ToLower();
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                throw new SocialException("Invalid email format");

            Username = username;
            Email = email;
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        public bool IsFollowing(string username) => _following.Contains(username);

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            content = content.Trim();

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content);
            _posts.Add(post);
            OnNewPost?.Invoke(post);
        }

        public IReadOnlyList<Post> GetPosts() => _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other == null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";

        internal IEnumerable<string> GetFollowingInternal() => _following;
    }

    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }

    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentException(nameof(author));

            Author = author;
            Content = content;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }

    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T? Find(Predicate<T> match) => _items.Find(match);
    }

    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime time)
        {
            var diff = DateTime.UtcNow - time;

            if (diff.TotalSeconds < 60)
                return "just now";
            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours} h ago";

            return time.ToString("MMM dd");
        }
    }

    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            return user.GetFollowingInternal();
        }
    }

    class Program
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";
        private static readonly string _logFile = "errors.log";

        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, $"Error: {ex.Message}");
                    if (ex.InnerException != null)
                        ConsoleColorWrite(ConsoleColor.Red, ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error!!");
                    Console.WriteLine(ex);
                    LogError(ex);
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("\n1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "0": SaveData(); Environment.Exit(0); break;
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
                throw new SocialException("Invalid input");

            if (_users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            var user = new User(username, email);
            _users.Add(user);

            ConsoleColorWrite(ConsoleColor.Green, $"Welcome {user.Username}!");
        }

        static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;
            _currentUser.OnNewPost += p =>
            {
                var preview = p.Content.Length > 40 ? p.Content[..40] + "..." : p.Content;
                ConsoleColorWrite(ConsoleColor.Cyan, $"New post by {p.Author}: {preview}");
            };

            ConsoleColorWrite(ConsoleColor.Green, $"Logged in as {user.Username}!");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine($"\nLogged in as {_currentUser}");
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. View timeline");
            Console.WriteLine("4. Follow user");
            Console.WriteLine("5. List users");
            Console.WriteLine("6. Logout");
            Console.WriteLine("0. Exit and save");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser!.GetPosts()); break;
                case "3": ShowTimeline(); break;
                case "4": FollowUser(); break;
                case "5": ListUsers(); break;
                case "6": _currentUser = null; break;
                case "0": SaveData(); Environment.Exit(0); break;
            }
        }

        static void PostMessage()
        {
            Console.WriteLine("Max 280 characters. Empty input cancels.");
            Console.Write("Post: ");
            var content = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Post cancelled.");
                return;
            }

            _currentUser!.AddPost(content);
            ConsoleColorWrite(ConsoleColor.Green, "Post published!");
        }

        static void ShowTimeline()
        {
            var timeline = new List<Post>();
            timeline.AddRange(_currentUser!.GetPosts());

            foreach (var name in _currentUser.GetFollowingNames())
            {
                var user = _users.Find(u => u.Username.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                    timeline.AddRange(user.GetPosts());
            }

            var sorted = timeline.OrderByDescending(p => p.CreatedAt);
            Console.WriteLine("=== Your Timeline ===");
            ShowPosts(sorted);
        }

        static void ShowPosts(IEnumerable<Post> posts)
        {
            int count = 0;

            foreach (var post in posts.Take(20))
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine(new string('-', 40));
                count++;
            }

            if (count == 0)
                Console.WriteLine("No posts yet.");
        }

        static void FollowUser()
        {
            Console.Write("Username to follow: ");
            var username = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Cancelled.");
                return;
            }

            var target = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (target == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            _currentUser!.Follow(username);
            ConsoleColorWrite(ConsoleColor.Green, $"Now following @{username}");
        }

        static void ListUsers()
        {
            Console.WriteLine("Registered users:");
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine($"{user,-20} {user.Email}");
        }

        static void SaveData()
        {
            try
            {
                var data = _users.GetAll().Select(u => new
                {
                    u.Username,
                    u.Email,
                    Following = u.GetFollowingNames().ToList(),
                    Posts = u.GetPosts().Select(p => new
                    {
                        p.Content,
                        p.CreatedAt
                    }).ToList()
                });

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_dataFile, json);
                Console.WriteLine("Data saved.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to save data.");
            }
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile)) return;
                File.ReadAllText(_dataFile);
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to load data.");
            }
        }

        static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText(_logFile,
                    $"{DateTime.Now}\n{ex.Message}\n{ex.StackTrace}\n\n");
            }
            catch { }
        }

        static void ConsoleColorWrite(ConsoleColor color, string text)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }
    }
}
