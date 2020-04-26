using KanBanDev.Models;
using KanBanDev.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace KanBanDev.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastro(FormCollection Formulario)
        {
            Retorno RetornoJson = new Retorno();
            Usuario NovoUsuario = new Usuario();

            try
            {
                //IQueryable<Usuario> UsuarioEmail = new Repository.UsuarioRepository().ObterUsuarioPorEmail(Email);

                RetornoJson.Status = Retorno.Resultado.Ok;
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErroGenericoRecuperarAcesso", "Ocorreu Um Erro Ao Tentar Cadastrar Usuário, Por Favor Tente Novamente.");
            }

            if (ModelState.IsValid)
            {
                RetornoJson.Status = Retorno.Resultado.Erro;
                RetornoJson.Erros = Retorno.ExtrairErrosModelState(ModelState);
            }
            else
            {
                RetornoJson.Status = Retorno.Resultado.Ok;
            }

            return Json(RetornoJson);
        }

        [HttpGet]
        public IActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Recuperar(String Email)
        {
            Retorno RetornoJson = new Retorno();

            try
            {
                IQueryable<Usuario> UsuarioEmail = new Repository.UsuarioRepository().ObterUsuarioPorEmail(Email);

                RetornoJson.Status = Retorno.Resultado.Ok;
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErroGenericoRecuperarAcesso", "Ocorreu Um Erro Ao Tentar Recuperar o Acesso Por E-mail, Por Favor Tente Novamente.");
            }

            if (ModelState.IsValid)
            {
                RetornoJson.Status = Retorno.Resultado.Erro;
                RetornoJson.Erros = Retorno.ExtrairErrosModelState(ModelState);
            }
            else
            {
                RetornoJson.Status = Retorno.Resultado.Ok;
            }

            return Json(RetornoJson);
        }
    }
}