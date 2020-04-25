using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class Permissao
    {
        public Permissao()
        {
            PermissaoUsuario = new HashSet<PermissaoUsuario>();
        }

        public int PermissaoId { get; set; }
        public string PermissaoDescricao { get; set; }

        public virtual ICollection<PermissaoUsuario> PermissaoUsuario { get; set; }
    }
}
