using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAppWeb.Controllers
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("500")]
        public IActionResult PageNotFound2()
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            

            var reExecuteFeature = feature as StatusCodeReExecuteFeature;
            string ErrorPathBase  = reExecuteFeature?.OriginalPathBase;
           string ErrorQuerystring  = reExecuteFeature?.OriginalQueryString;

            var OriginalPath = feature?.OriginalPath;


            return new ObjectResult(new { Message = "Ocurrio un error al solicitar " + OriginalPath, ErrorPathBase = ErrorPathBase, ErrorQuerystring = ErrorQuerystring, OriginalPath = OriginalPath });
        }

       
    }
}
