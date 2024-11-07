using System;
using System.Collections.Generic;

public interface FileSystemComponent
{
    string Name { get; }
    int GetSize();
    void Display(int indent = 0);
}

public class File : FileSystemComponent
{
    public string Name { get; }
    private int _size;

    public File(string name, int size)
    {
        Name = name;
        _size = size;
    }

    public int GetSize() => _size;

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "- " + Name + " (" + _size + " KB)");
    }
}

public class Directory : FileSystemComponent
{
    public string Name { get; }
    private List<FileSystemComponent> _components = new List<FileSystemComponent>();

    public Directory(string name)
    {
        Name = name;
    }

    public int GetSize()
    {
        int totalSize = 0;
        foreach (var component in _components)
        {
            totalSize += component.GetSize();
        }
        return totalSize;
    }

    public void Add(FileSystemComponent component)
    {
        if (!_components.Contains(component))
            _components.Add(component);
    }

    public void Remove(FileSystemComponent component)
    {
        if (_components.Contains(component))
            _components.Remove(component);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + "+ " + Name + " (" + GetSize() + " KB)");
        foreach (var component in _components)
        {
            component.Display(indent + 2);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var file1 = new File("File1.txt", 10);
        var file2 = new File("File2.txt", 20);
        var subDirectory = new Directory("SubFolder");
        subDirectory.Add(file1);
        
        var mainDirectory = new Directory("MainFolder");
        mainDirectory.Add(subDirectory);
        mainDirectory.Add(file2);
        
        mainDirectory.Display();
    }
}
