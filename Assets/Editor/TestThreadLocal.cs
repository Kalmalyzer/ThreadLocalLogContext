using NUnit.Framework;
using System;
using System.Threading;

public class TestThreadLocal
{
    public static ThreadLocal<int> perThreadCounter;

    public static void threadFunction()
    {
        Assert.AreEqual(0, perThreadCounter.Value);
        perThreadCounter.Value = 1;
    }

    [Test]
    public void TestThreadLocalVariables()
    {
        {
            Thread thread1 = new Thread(threadFunction);
            thread1.Start();
            thread1.Join();
        }

        {
            Thread thread2 = new Thread(threadFunction);
            thread2.Start();
            thread2.Join();
        }
    }
}
