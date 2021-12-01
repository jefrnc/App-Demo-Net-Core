using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyAppWeb.Pages
{
    public class Bomb2 : Controller
    {
        public static bool IsBroken = false;
        public IActionResult Index()
        {
            IsBroken = true;
            return Redirect("/");
        }
    }
}
