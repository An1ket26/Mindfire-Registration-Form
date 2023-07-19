using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

public class FileWatcher
{
    public static void Main()
    {
        string path = ConfigurationManager.AppSettings.Get("Key0");
        Console.WriteLine(path);

        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(path);
        
        fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
        fileSystemWatcher.Filter = "*";
        fileSystemWatcher.IncludeSubdirectories = true;
        fileSystemWatcher.EnableRaisingEvents = true;
        

        fileSystemWatcher.Changed += OnChanged;
        fileSystemWatcher.Created += OnCreated;
        fileSystemWatcher.Deleted += OnDeleted;
        fileSystemWatcher.Renamed += OnRenamed;
        Console.ReadLine();
    }

    public static void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine();
        string message = e.Name + " with path " + e.FullPath + " has been " + e.ChangeType;
        LogRecord(message);
    }
    public static void OnCreated(object sender, FileSystemEventArgs e)
    {
        string message = e.Name + " with path " + e.FullPath + " has been " + e.ChangeType;
        LogRecord(message);
    }
    public static void OnDeleted(object sender, FileSystemEventArgs e)
    {
        string message = e.Name + " with path " + e.FullPath + " has been " + e.ChangeType;
        LogRecord(message);
    }
    public static void OnRenamed(object sender, RenamedEventArgs e)
    {
        string message = e.Name + " with path " + e.OldFullPath + " has been renamed to" + e.FullPath;
        LogRecord(message);
    }

    public static void LogRecord(string message)
    {
        Console.WriteLine(message);   
        string pathName =Path.Combine(DateTime.Now.ToString("yyyy-MM-dd")+".txt");
        if (File.Exists(pathName))
        {
            File.AppendAllText(pathName, message + Environment.NewLine);
        }
        else
        {
            File.WriteAllText(pathName, message + Environment.NewLine);
        }
    }
}