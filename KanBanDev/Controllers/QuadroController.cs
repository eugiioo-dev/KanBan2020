using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KanBanDev.Controllers
{
    public class QuadroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}