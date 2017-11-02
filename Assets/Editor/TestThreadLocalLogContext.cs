using NUnit.Framework;
using System.Threading;

public class TestThreadLocalLogContext
{
    private static void innerThreadFunction()
    {
        using (LogScope logScope = ThreadLocalLogContext.Scope("inner thread scope"))
        {
            Assert.AreEqual("inner thread scope", ThreadLocalLogContext.LogContextForCurrentThread.Value.Get());
        }
    }

    private static void outerThreadFunction()
    {
        using (LogScope logScope = ThreadLocalLogContext.Scope("outer thread scope"))
        {
            Assert.AreEqual("outer thread scope", ThreadLocalLogContext.LogContextForCurrentThread.Value.Get());

            Thread thread1 = new Thread(innerThreadFunction);
            thread1.Start();
            thread1.Join();

            Assert.AreEqual("outer thread scope", ThreadLocalLogContext.LogContextForCurrentThread.Value.Get());
        }
    }

    [Test]
    public void TestThreadLocalLogContexts()
    {
        {
            Thread thread1 = new Thread(outerThreadFunction);
            thread1.Start();
            thread1.Join();
        }
    }

}
