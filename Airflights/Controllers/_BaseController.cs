using Airflights.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airflights.Controllers
{
    public abstract class _BaseController : ControllerBase
    {
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(new ApiResponse<object>(value));
        }
    }
}
