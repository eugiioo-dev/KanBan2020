using KanBanDev.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanDev.Repository
{
    public class UsuarioRepository
    {
        private readonly KanBanContext Contexto;

        public UsuarioRepository()
        {
            if(Contexto == null)
            {
                Contexto = new KanBanContext();
            }
        }

        public Usuario ObterUsuarioPorId(Int32? IdUsuario)
        {
            return Contexto.Usuario.Where(x => x.UsuarioId == IdUsuario).FirstOrDefault();
        }

        public Usuario ObterUsuarioPorIdComRelacionamentos(Int32? IdUsuario)
        {
            return Contexto.Usuario.Include(r => r.Quadro).ThenInclude(r => r.Tarefa).Include(r => r.PermissaoUsuario).ThenInclude(r => r.Permissao).Where(x => x.UsuarioId == IdUsuario).FirstOrDefault();
        }

        public IQueryable<Usuario> ObterUsuarioPorEmail(String EmailUsuario)
        {
            return Contexto.Usuario.Where(x => x.UsuarioEmail == EmailUsuario);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return Contexto.Usuario;
        }

        public Usuario RegistrarAcesso(Usuario UsuarioAcesso)
        {
            UsuarioAcesso.UsuarioDtUltimoAcesso = DateTime.Now;
            Contexto.Usuario.Attach(UsuarioAcesso);
            Contexto.Entry(UsuarioAcesso).State = EntityState.Modified;
            Contexto.SaveChanges();

            return UsuarioAcesso;
        }
    }
}
