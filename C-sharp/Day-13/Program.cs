using System.Text.Json;
using System.Xml.Serialization;
// class FileIo
// {
//     public static void Main(string[] args)
//     {
        // string path="data.txt";
        // File.WriteAllText(path,"File Io in c#");
        // File.WriteAllText(path,"updated text");
        // Console.WriteLine("Data written to file");
        // string Content=File.ReadAllText(path);
        // Console.WriteLine("File Content: ");
        // Console.WriteLine(Content);
        // using(StremWriter writer=new StremWriter("log.txt"))
        // {
        //     writer.WriteLine("Application Started");
        //     writer.WriteLine("Processing Data");
        //     writer.WriteLine("Application Ended");
        // }
        // using(StreamReader reader=new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine(line);
        //     }
        // }
//     }
// }
// class User
// {
//     public int Id;
//     public string Name;
// }

class Program
{
    static void Main()
    {
        // User user = new User { Id = 1, Name = "Alice" };

        // using (StreamWriter writer = new StreamWriter("user.txt"))
        // {
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        //     user.Id=2;
        //     user.Name="Bob";
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        // }

        // Console.WriteLine("User data saved.");

        // User user = new User();

        // using (StreamReader reader = new StreamReader("user.txt"))
        // {
        //     user.Id = int.Parse(reader.ReadLine()); 
        //     user.Name = reader.ReadLine();
        // }

        // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");

        // User user = new User { Id = 2, Name = "Bob" };

        // using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        // {
        //     writer.Write(user.Id);
        //     writer.Write(user.Name);
        // }

        // Console.WriteLine("Binary user data saved.");
        // using (BinaryReader reader = new BinaryReader(File.Open("user.bin", FileMode.Open)))
        // {
        //     Console.WriteLine(reader.ReadInt32());
        //     Console.WriteLine(reader.ReadString());
        // }

        // FileInfo file = new FileInfo("sample.txt");

        // if (!file.Exists)
        // {
        //     using (StreamWriter writer = file.CreateText())
        //     {
        //         writer.WriteLine("Hello FileInfo Class");
        //     }
        // }

        // Console.WriteLine("File Name: " + file.Name);
        // Console.WriteLine("File Size: " + file.Length + " bytes");
        // Console.WriteLine("Created On: " + file.CreationTime);

        // Directory.CreateDirectory("Logs");

        // if (Directory.Exists("Logs"))
        // {
        //     Console.WriteLine("Logs directory created successfully.");
        // }

        // DirectoryInfo dir = new DirectoryInfo("Logs");

        // if (!dir.Exists)
        // {
        //     dir.Create();
        // }

        // Console.WriteLine("Directory Name: " + dir.Name);
        // Console.WriteLine("Created On: " + dir.CreationTime);
        // Console.WriteLine("Full Path: " + dir.FullName);

        // User user = new User { Id = 2, Name = "Bob" };

        // string json = JsonSerializer.Serialize(user);

        // File.WriteAllText("user.json", json);

        // Console.WriteLine("User serialized successfully.");

        // string json = File.ReadAllText("user.json");

        // User user = JsonSerializer.Deserialize<User>(json);

        // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");

        User user = new User { Id = 1, Name = "Alice" };
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs, user);
        }

        Console.WriteLine("XML Serialized");
        Console.WriteLine(typeof(User));

    }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

