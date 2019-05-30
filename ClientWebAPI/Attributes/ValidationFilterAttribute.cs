using ClientWebAPI.Extensions;
using ClientWebAPI.Model.Errors;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace ClientWebAPI.Attributes
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid)
            {
                return; 
            }

            var errors = new List<BaseError>();

            if (context.ModelState.ContainsKey("id"))
            {
                ValidateId(context, errors);
            }

            ValidateDto(context, errors);

            var response = ResponseHelper.GetErrorResponse(errors, context.HttpContext.Request.Path, "Error in sending data");
            context.Result = new BadRequestObjectResult(response);
        }

        private void ValidateId(ActionExecutingContext context, List<BaseError> errors)
        {
            var id = context.ModelState["id"].RawValue;
            if(id == null)
            {
                errors.Add(new NoParameterSpecifiedError("id"));
            }
            else
            {
                errors.Add(new WrongParameterValueError("id"));
            }
        }

        private void ValidateDto(ActionExecutingContext context, List<BaseError> errors)
        {
            var dto = context.ActionArguments.SingleOrDefault(d => d.Value is IValidationDto).Value;
            if (dto == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            var keys = context.ModelState.Keys.Where(k => !string.IsNullOrEmpty(k) && !k.Equals("id"));
            foreach (var key in keys)
            {
                var property = dto.GetType().GetProperty(key);
                if (property.GetValue(dto) == null)
                {
                    errors.Add(new NoParameterSpecifiedError(key.ToCamelCase()));
                }
                else
                {
                    errors.Add(new WrongParameterValueError(key.ToCamelCase()));
                }
            }
        }
       
    }
}
