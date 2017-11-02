using System.Collections.Generic;

public class LogContext
{
    public List<string> stack = new List<string>();

    public List<string> Messages = new List<string>();

    public void Enter(string name)
    {
        stack.Add(name);
    }

    public string Get()
    {
        return string.Join(".", stack.ToArray());
    }

    public void Exit()
    {
        stack.RemoveAt(stack.Count - 1);
    }
}
