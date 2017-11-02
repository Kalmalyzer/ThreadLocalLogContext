public class ThreadLocalLogContext
{
    public static System.Threading.ThreadLocal<LogContext> LogContextForCurrentThread;

    public static LogScope Scope(string name)
    {
        return new LogScope(LogContextForCurrentThread.Value, name);
    }
}
