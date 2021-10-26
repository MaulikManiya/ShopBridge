using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopBridge.API.Infrastructure.Errors
{
    public class ValidationResultModel
    {
        public string Message { get; }
        public ErrorCodes ErrorCode { get; }
        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            ErrorCode = ErrorCodes.ValidationModelError;
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}