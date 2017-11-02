using System.Collections.Generic;
using System.Linq;

public class LogContext
{
    private List<LogScope> stack = new List<LogScope>();

    public void Enter(LogScope scope)
    {
        stack.Add(scope);
    }

    public string Get()
    {
        return string.Join(".", stack.Select(scope => scope.Name).ToArray());
    }

    public void Exit(LogScope scope)
    {
        if (stack[stack.Count - 1] != scope)
            throw new System.Exception("Incorrect scope winding order: current stack is " + Get() + " when attempting to exit scope " + scope.Name);
        else
           stack.RemoveAt(stack.Count - 1);
    }
}
