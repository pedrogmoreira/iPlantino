using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace iPlantino.Services.Api.Infrastructure.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = context.ModelState
                .Keys
                .ToDictionary(
                    key => key,
                    key => context.ModelState[key]
                        .Errors
                        .Select(s => s.ErrorMessage));

                context.Result = new BadRequestObjectResult(validationErrors);
            }
        }
    }
}