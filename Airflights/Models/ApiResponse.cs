using AirflightsShared.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airflights.Models
{
    public class ApiResponse
    {
        public ApiResponse(ResultCode resultCode, string message = "")
        {
            this.resultCode = resultCode;
            this.Message = message;
        }
        public ResultCode resultCode { get; set; }
        public string Message { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(T data) : base(ResultCode.Ok)
        {
            this.Data = data;
        }

        public T Data { get; set; }
    }

    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse(List<ValidationError> validationErrors) : base(ResultCode.ModelValidationError, "ModelValidationError")
        {
            this.ValidationErrors = validationErrors ?? new List<ValidationError>();
        }

        public ApiValidationErrorResponse(ModelStateDictionary modelState) : base(ResultCode.ModelValidationError, "ModelValidationError")
        {
            this.ValidationErrors =  new List<ValidationError>();

            foreach (var error in modelState)
            {
                this.ValidationErrors.AddRange(error.Value.Errors.Select(x => new ValidationError(error.Key, x.ErrorMessage)));
            }
        }
        public List<ValidationError> ValidationErrors { get; set; }
    }
}
