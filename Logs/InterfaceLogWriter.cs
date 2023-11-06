namespace Logs;

public interface InterfaceLogWriter
{
    /// <summary>
    /// Écrit un message dans le journal.
    /// </summary>
    /// <param name="message">Le message à enregistrer dans le journal.</param>
    /// <param name="messageConsole">Indique si le message doit également être affiché dans la console.</param>
    void WriteLog(string message, bool messageConsole);
}