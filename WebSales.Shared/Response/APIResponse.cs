using Microsoft.AspNetCore.Mvc;

namespace WebSales.Shared.Response
{
    public abstract class APIResponse : Controller
    {
        protected static IActionResult CreateAPIResult<T>(APIResult<ErrorResult, T> apiResult)
        {
            if (apiResult.Succeeded)
                return new OkObjectResult(apiResult.Success);

            return new BadRequestObjectResult(apiResult.Failure);
        }
    }
}
