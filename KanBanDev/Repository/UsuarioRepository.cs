using KanBanDev.Models;
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

        public Usuario ObterUsuarioPorId(Int32 IdUsuario)
        {
            return Contexto.Usuario.Where(x => x.UsuarioId == IdUsuario).FirstOrDefault();
        }

        public IQueryable<Usuario> ObterUsuarioPorEmail(String EmailUsuario)
        {
            return Contexto.Usuario.Where(x => x.UsuarioEmail == EmailUsuario);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return Contexto.Usuario;
        }
    }
}
