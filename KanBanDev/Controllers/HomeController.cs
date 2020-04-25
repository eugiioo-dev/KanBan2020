using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KanBanDev.Models;
using Microsoft.EntityFrameworkCore;

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
            //using (var context = new Models.KanBanContext())
            //{
            //    var blogs = context.Usuario
            //        .Include(permissaoUsuario => permissaoUsuario.PermissaoUsuario)
            //            .ThenInclude(permissao => permissao.Permissao).ToList();
            //}

            //retorno.UsuarioDtCadastro = DateTime.Now;
            //retorno.UsuarioDtUltimoAcesso = retorno.UsuarioDtCadastro;

            //Contexto.Usuario.Attach(retorno);
            //Contexto.Entry(retorno).State = EntityState.Modified;
            //Contexto.SaveChanges();

            return View();
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
