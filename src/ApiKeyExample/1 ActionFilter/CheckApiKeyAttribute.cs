using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiKeyExample;

public class CheckApiKeyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKeyHeaderValues))
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        var apiKeyRepository = context.HttpContext.RequestServices.GetRequiredService<IApiKeyRepository>();
        var apiKey = apiKeyRepository.GetKey(apiKeyHeaderValues.FirstOrDefault());

        if (apiKey == null)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        base.OnActionExecuting(context);
    }
}