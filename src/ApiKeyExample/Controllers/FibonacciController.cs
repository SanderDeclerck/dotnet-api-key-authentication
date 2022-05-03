using Microsoft.AspNetCore.Mvc;

namespace ApiKeyExample.Controllers;

[ApiController]
[CheckApiKey]
public class FibonacciController : ControllerBase
{
    [HttpGet("/api/fibonacci/{n}")]
    public int Fib(int n)
    {
        int a = 0, b = 1;
        for (var i = 0; i < n; i++)
        {
            (a, b) = (b, a + b);
        }
        return a;
    }
}
