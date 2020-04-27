using KanBanDev.Models;
using KanBanDev.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public JsonResult Login(IFormCollection Formulario)
        {
            Retorno RetornoJson = new Retorno();

            try
            {
                String Email = Formulario["UsuarioEmail"].ToString();
                String Senha = Util.Geral.ConverterTextoParaBase64(Formulario["UsuarioSenha"].ToString());

                Repository.UsuarioRepository RepoUsuario = new Repository.UsuarioRepository();

                List<Usuario> UsuarioEmail = RepoUsuario.ObterUsuarioPorEmail(Email).ToList();
                Usuario UsuarioLogin = UsuarioEmail.FirstOrDefault();

                if (UsuarioEmail.Count() > 1)
                {
                    ModelState.AddModelError("ErroGenericoLogin", "Ocorreu Um Erro Ao Efetuar Login, Por Favor Tente Novamente.");
                } 
                else
                if(UsuarioEmail.Count() == 0 || UsuarioLogin.UsuarioSenha != Senha)
                {
                    ModelState.AddModelError("ErroUsuarioNaoEncontrado", "O e-mail ou a senha é inválido.");
                }
                else
                if(UsuarioLogin.UsuarioSituacao == false)
                {
                    ModelState.AddModelError("ErroConfirmacaoDeEmail", "O Usuário não está ativo.");
                }
                else
                {
                    RepoUsuario.RegistrarAcesso(UsuarioLogin);

                    HttpContext.Session.SetInt32("UsuarioID", UsuarioLogin.UsuarioId);
                    HttpContext.Session.SetString("UsuarioNome", UsuarioLogin.UsuarioNome);
                    HttpContext.Session.SetString("UsuarioDtHrUltimoAcesso", UsuarioLogin.UsuarioDtUltimoAcesso.ToString());
                    HttpContext.Session.SetString("UsuarioDtHrLogin", DateTime.Now.ToString());
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("ErroGenericoLogin", "Ocorreu um erro ao efetuar login, por favor tente novamente.");
            }

            if (!ModelState.IsValid)
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