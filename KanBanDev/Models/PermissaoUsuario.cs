using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class PermissaoUsuario
    {
        public int PermissaoUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int PermissaoId { get; set; }

        public virtual Permissao Permissao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
