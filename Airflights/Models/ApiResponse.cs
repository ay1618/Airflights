using AirflightsShared.Enums;
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
}
