namespace FileInteraction;

public class FileWriter
{
    private static FileWriter instance = null;
    private static readonly object lockObject = new object();
    public static FileWriter Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new FileWriter();
                }
                return instance;
            }
        }
    }

    private FileWriter() { }

    public bool WriteToFile(string FilePath, string Content)
    {
        try
        {
            // Écrit le contenu dans le fichier spécifié par le chemin FilePath.
            File.WriteAllText(FilePath, Content);
            return true; // L'écriture a réussi.
        }
        catch (IOException e)
        {
            return false; // Une erreur s'est produite lors de l'écriture dans le fichier.
        }
    }

    public bool FileExiste(string FilePath)
    {
        return File.Exists(FilePath); // Renvoie true si le fichier existe à l'emplacement spécifié, sinon false.
    }

    public bool CreateFile(string FilePath)
    {
        try
        {
            // Crée un nouveau fichier au chemin FilePath.
            File.Create(FilePath);
            return true; // La création du fichier a réussi.
        }
        catch (IOException e)
        {
            return false; // Une erreur s'est produite lors de la création du fichier.
        }
    }
}