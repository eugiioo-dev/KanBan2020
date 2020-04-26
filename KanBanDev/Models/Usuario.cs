using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            PermissaoUsuario = new HashSet<PermissaoUsuario>();
            Quadro = new HashSet<Quadro>();
        }

        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }
        public DateTime UsuarioDtCadastro { get; set; }
        public DateTime UsuarioDtUltimoAcesso { get; set; }
        public bool UsuarioEmailConfirmado { get; set; }
        public bool UsuarioSituacao { get; set; }

        public virtual ICollection<PermissaoUsuario> PermissaoUsuario { get; set; }
        public virtual ICollection<Quadro> Quadro { get; set; }
    }
}
