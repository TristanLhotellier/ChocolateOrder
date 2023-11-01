using System.Configuration;
namespace Logs;

public class LogWriter
{
    public LogWriter() { }

    public void WriteLog(string message, bool messageConsole)
    {
        string path = string.Format(ConfigurationManager.AppSettings["pathLogs"] +DateTime.Today.ToString("dd-MM-yyyy ss") + "{0}", ".txt");
        message = "[" + DateTime.Now.ToString() + "] " + message + "\n";
        File.AppendAllText(path, message);
        if (messageConsole)
        {
            Console.WriteLine(message);
        }
    }
}