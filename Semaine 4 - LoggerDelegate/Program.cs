// Multicast Delegate log
public class Logger
{
    public delegate void DelegateLog(string msg);

    private DelegateLog _delegateCallBack;

    public DelegateLog DelegateCallBack
    {
        get { return _delegateCallBack; }
        set { _delegateCallBack = value; }
    }

    // Log a message using the registered method
    public void LogMessage(string message)
    {
        _delegateCallBack?.Invoke(message);
    }
}

public static class ConsoleLogger
{
    public static void LogToConsole(string msg)
    {
        Console.WriteLine(msg);
    }
}

public static class FileLogger
{
    public static void LogToFile(string msg)
    {
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "log.txt")))
        {
            outputFile.WriteLine(msg);
        }
    }
}


class Test
{
    public static void Main(string[] args)
    {
        Logger log = new Logger();
        log.DelegateCallBack += ConsoleLogger.LogToConsole;
        log.DelegateCallBack += FileLogger.LogToFile;

        log.LogMessage("test");
    }

}
