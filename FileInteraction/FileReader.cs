namespace FileInteraction;

public class FileReader
{
    public FileReader() { }
    public string Read(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content;
    }
}