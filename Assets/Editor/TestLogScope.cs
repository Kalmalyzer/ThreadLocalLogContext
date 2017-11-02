using NUnit.Framework;

public class TestLogScope
{
    [Test]
    public void TestLogScopes()
    {
        LogContext logContext = new LogContext();
        using (LogScope logScope1 = new LogScope(logContext, "scope 1"))
        {
            Assert.AreEqual(1, logContext.stack.Count);
            Assert.AreEqual("scope 1", logContext.Get());

            using (LogScope logScope2 = new LogScope(logContext, "scope 2"))
            {
                // Ensure log scopes flatten in first-to-last order
                Assert.AreEqual("scope 1.scope 2", logContext.Get());
            }

            // Ensure that when a scope goes out-of-scope the appropriate scope is being removed
            Assert.AreEqual(1, logContext.stack.Count);
            Assert.AreEqual("scope 1", logContext.Get());
        }

        Assert.AreEqual(0, logContext.stack.Count);
    }

}
