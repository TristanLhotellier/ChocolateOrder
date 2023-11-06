namespace FileInteraction;

public class FileReader : InterfaceFileReader
{
    public FileReader() { }
    public string Read(string filePath)
    {
        string content = File.ReadAllText(filePath);
        return content;
    }
}