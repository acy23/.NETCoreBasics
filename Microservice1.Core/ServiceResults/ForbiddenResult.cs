using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice1.Core.ServiceResults
{
    public class ForbiddenResult <T> : IServiceResult<T> where T : class
    {
        private readonly string _reason;

        public ForbiddenResult(string reason)
        {
            _reason = reason;
        }
        public JsonResult ToApiResult()
        {
            return new JsonResult(_reason)
            {
                ContentType = "application/json",
                StatusCode = 403
            };
        }

    }
}
