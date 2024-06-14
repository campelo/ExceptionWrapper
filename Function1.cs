using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ExceptionWrapper;

public class Function1(ILogger<Function1> logger, IMyService1 myService1)
{
    [Function("Function1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        try
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");
            myService1.DoWork("Hello from Azure Functions!");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
        catch (Exception ex)
        {

            throw;
        }

    }
}
