using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice1.Core.ServiceResults
{
    public class NoContentResult : IServiceResult
    {
        public NoContentResult()
        {
            
        }
        public JsonResult ToApiResult()
        {
            return new JsonResult(null)
            {
                ContentType = "application/json",
                StatusCode = 204
            };
        }

    }
}
