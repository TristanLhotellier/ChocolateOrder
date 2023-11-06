namespace Logs;

public interface InterfaceLogWriter
{
    /// <summary>
    /// Write a message in the log
    /// </summary>
    /// <param name="message">The message to register in the log</param>
    /// <param name="messageConsole">Indicates whether the message should also be displayed in the console.</param>
    void WriteLog(string message, bool messageConsole);
}