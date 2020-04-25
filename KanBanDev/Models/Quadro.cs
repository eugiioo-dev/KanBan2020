using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class Quadro
    {
        public Quadro()
        {
            Tarefa = new HashSet<Tarefa>();
        }

        public int QuadroId { get; set; }
        public string QuadroDescricao { get; set; }
        public DateTime QuadroDtCriacao { get; set; }
        public bool? QuadroSituacao { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
