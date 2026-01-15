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
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is invalid");

            username = username.Trim();

            email = email.Trim().ToLower();
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
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

        public bool IsFollowing(string username) =>
            _following.Contains(username);

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

        public IReadOnlyList<Post> GetPosts() =>
            _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other is null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";
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

        public IReadOnlyList<T> GetAll() =>
            _items.AsReadOnly();

        public T? Find(Predicate<T> match) =>
            _items.Find(match);
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
    class Program
    {
        private static Repository<User> _users = new();
        private static User? _currentUser;

        private static readonly string _dataFile = "users.json";
        private static readonly string _logFile = "errors.log";

        static void Main()
        {
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
                catch (Exception ex)
                {
                    LogError(ex);
                    ConsoleColorWrite(ex.Message, ConsoleColor.Red);
                }
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("\n--- MiniSocial ---");
            Console.WriteLine("1. Register");
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
            string username = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            var user = new User(username, email);
            user.OnNewPost += _ => ConsoleColorWrite("New post created!", ConsoleColor.Green);

            _users.Add(user);
            ConsoleColorWrite("User registered successfully", ConsoleColor.Green);
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;

            _currentUser = _users.Find(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (_currentUser == null)
                throw new SocialException("User not found");

            ConsoleColorWrite($"Welcome {_currentUser.Username}!", ConsoleColor.Green);
        }

        static void ShowMainMenu()
        {
            Console.WriteLine($"\nLogged in as {_currentUser}");
            Console.WriteLine("1. Post Message");
            Console.WriteLine("2. View Timeline");
            Console.WriteLine("3. Follow User");
            Console.WriteLine("4. List Users");
            Console.WriteLine("5. Logout");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": PostMessage(); break;
                case "2": ShowTimeline(); break;
                case "3": FollowUser(); break;
                case "4": ListUsers(); break;
                case "5": _currentUser = null; break;
            }
        }

        static void PostMessage()
        {
            Console.Write("Enter post: ");
            string content = Console.ReadLine()!;
            _currentUser!.AddPost(content);
        }

        static void ShowTimeline()
        {
            var timeline =
                _users.GetAll()
                      .Where(u => u.Username == _currentUser!.Username ||
                                  _currentUser.IsFollowing(u.Username))
                      .SelectMany(u => u.GetPosts())
                      .OrderByDescending(p => p.CreatedAt);

            foreach (var post in timeline)
            {
                Console.WriteLine(post);
                Console.WriteLine($"({post.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine(new string('-', 40));
            }
        }

        static void FollowUser()
        {
            Console.Write("Enter username to follow: ");
            string username = Console.ReadLine()!;
            _currentUser!.Follow(username);
            ConsoleColorWrite("Followed successfully", ConsoleColor.Green);
        }

        static void ListUsers()
        {
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine(user.GetDisplayName());
        }

        static void SaveData()
        {
            var json = JsonSerializer.Serialize(_users.GetAll(),
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_dataFile, json);
        }

        static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            var json = File.ReadAllText(_dataFile);
            var users = JsonSerializer.Deserialize<List<User>>(json);

            if (users == null) return;

            foreach (var user in users)
                _users.Add(user);
        }

        static void LogError(Exception ex)
        {
            File.AppendAllText(_logFile, $"{DateTime.Now}: {ex}\n");
        }

        static void ConsoleColorWrite(string message, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = old;
        }
    }
}
