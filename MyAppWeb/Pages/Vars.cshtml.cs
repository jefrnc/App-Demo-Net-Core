using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyAppWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private IHostingEnvironment _environment;

        public PrivacyModel(ILogger<PrivacyModel> logger, IHostingEnvironment environment)
        {
            _logger = logger;
            _environment = environment;

        }


         

        public void OnGet()
        {


            var filePath = System.IO.Path.Combine(_environment.ContentRootPath, "version.txt");
            ViewData["version"] = System.IO.File.ReadAllText(filePath);
            //System.IO.Path.Combine(this.HttpContext.  .WebRootPath, "version.txt")
            //var fileContents = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/version.txt"));
        }
    }
}
