using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice1.Core.ServiceResults
{
    public interface IServiceResult<T> where T : class
    {
        JsonResult ToApiResult();
    }
}
