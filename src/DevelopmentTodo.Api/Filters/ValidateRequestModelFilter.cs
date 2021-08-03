using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevelopmentTodo.Api.Filters
{
    public class ValidateRequestModelFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid is false)
            {
                var errors = context.ModelState.Values
                    .SelectMany(modelState => modelState.Errors)
                    .Select(modelError => modelError.ErrorMessage);

                context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(
                    HttpStatusCode.BadRequest, errors));
            }

            await next();
        }
    }
}
