namespace FileInteraction;

public interface InterfaceFileWriter
{
    /// <summary>
    /// Writes content to a file.
    /// </summary>
    /// <param name="FilePath">The path to the file where to write the content.</param>
    /// <param name="Content">The content to write to the file.</param>
    /// <returns>True if the write succeeded, otherwise false.</returns>
    bool WriteToFile(string FilePath, string Content);

    /// <summary>
    /// Checks if a file exists.
    /// </summary>
    /// <param name="FilePath">The path to the file to check.</param>
    /// <returns>True if the file exists, otherwise false.</returns>
    bool FileExiste(string FilePath);

    /// <summary>
    /// Creates a new file.
    /// </summary>
    /// <param name="FilePath">The path to the file to create.</param>
    /// <returns>True if the file creation succeeded, otherwise false.</returns>
    bool CreateFile(string FilePath);
}