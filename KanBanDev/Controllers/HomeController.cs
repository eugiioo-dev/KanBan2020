using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KanBanDev.Models;
using Microsoft.EntityFrameworkCore;
using KanBanDev.Util;
using Microsoft.AspNetCore.Http;

namespace KanBanDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Int32? CodigoDoUsuario = HttpContext.Session.GetInt32("UsuarioID");

            if (CodigoDoUsuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                Usuario UsuarioLogado = new Repository.UsuarioRepository().ObterUsuarioPorIdComRelacionamentos(CodigoDoUsuario);
                return View(UsuarioLogado);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
