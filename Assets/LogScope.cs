using System;

public class LogScope : IDisposable
{
    private readonly LogContext context;

    public readonly string Name;

    public LogScope(LogContext context, string name)
    {
        this.context = context;
        Name = name;
        context.Enter(this);
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
            }

            // Free unmanaged resources (unmanaged objects) and override a finalizer below.
            // Set large fields to null.

            context.Exit(this);

            disposedValue = true;
        }
    }

    // Override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~LogScope() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
        // Uncomment the following line if the finalizer is overridden above.
        // GC.SuppressFinalize(this);
    }
    #endregion
}
