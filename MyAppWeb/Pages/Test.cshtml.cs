using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyAppWeb.Pages
{
    public class TestModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IHostingEnvironment _environment;
 

        public TestModel(ILogger<IndexModel> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
            
        }

        public IActionResult OnGet()
        {

            // var a = HttpContext.Request.Headers;
            // return 

             
            var model = new MessageJson("Hola! Son las " + DateTime.Now.ToString(), HttpContext.Request);
            var jsondata = JsonConvert.SerializeObject(model);
            return Content(jsondata);
        }

        public class MessageJson
        {
            public string Message { get; set; }
            public Dictionary<string, string> Headers { get; set; }
     
            public MessageJson(string message, HttpRequest _httpContextAccessor)
            {
                Message = message;
                /*_httpContextAccessor.Query
                    _httpContextAccessor.Body
                    _httpContextAccessor.ContentType
                    _httpContextAccessor.Form
                    _httpContextAccessor.Host
                    _httpContextAccessor.Protocol
                    _httpContextAccessor.Method
                    _httpContextAccessor.QueryString*/
                   

                Headers = new Dictionary<string, string>();
                foreach (var key in _httpContextAccessor.Headers.Keys)
                {
                    Headers.Add(key, _httpContextAccessor.Headers[key]);
                }
            }
        }
    }
}
