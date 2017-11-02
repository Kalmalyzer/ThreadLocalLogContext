using NUnit.Framework;
using System;

public class TestLogScope
{
    [Test]
    public void TestLogScopeNesting()
    {
        LogContext logContext = new LogContext();
        using (LogScope logScope1 = new LogScope(logContext, "scope 1"))
        {
            Assert.AreEqual("scope 1", logContext.Get());

            using (LogScope logScope2 = new LogScope(logContext, "scope 2"))
            {
                // Ensure log scopes flatten in first-to-last order
                Assert.AreEqual("scope 1.scope 2", logContext.Get());
            }

            // Ensure that when a scope goes out-of-scope the appropriate scope is being removed
            Assert.AreEqual("scope 1", logContext.Get());
        }

        Assert.AreEqual("", logContext.Get());
    }

    [Test]
    public void TestLogScopeIncorrectNesting()
    {
        LogContext logContext = new LogContext();

        LogScope logScope2 = null;

        {
            LogScope logScope1 = new LogScope(logContext, "scope 1");
            Assert.AreEqual("scope 1", logContext.Get());

            logScope2 = new LogScope(logContext, "scope 2");

            Assert.AreEqual("scope 1.scope 2", logContext.Get());

            // logScope1 is simulated to go out-of-scope before logScope2 by invoking Dispose() early; this should result in an exception/assert
            Assert.Throws(typeof(Exception), () => ((IDisposable)logScope1).Dispose());
        }
    }

}
