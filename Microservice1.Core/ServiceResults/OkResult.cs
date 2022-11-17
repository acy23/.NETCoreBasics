using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Microservice1.Core.ServiceResults
{
    public class OkResult<T> : IServiceResult<T> where T : class
    {
        private readonly T _data;

        public OkResult(T data)
        {
            _data = data;
        }
        public JsonResult ToApiResult()
        {
            return new JsonResult(_data)
            {
                ContentType = "application/json",
                StatusCode = 200
            };
        }
    }
}
