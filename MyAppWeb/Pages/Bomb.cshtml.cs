using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAppWeb.Pages
{
    public class BombModel : PageModel
    {
        public static bool IsBroken = false;
        public IActionResult  OnGet()
        {
            IsBroken = true;
            return new RedirectToPageResult("index");
        }
    }
}
