using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class Tarefa
    {
        public Tarefa()
        {
            HistoricoTarefa = new HashSet<HistoricoTarefa>();
        }

        public int TarefaId { get; set; }
        public int QuadroId { get; set; }
        public string TarefaTitulo { get; set; }
        public string TarefaDescricao { get; set; }
        public DateTime TarefaDtCriacao { get; set; }
        public int SituacaoTarefaId { get; set; }

        public virtual Quadro Quadro { get; set; }
        public virtual SituacaoTarefa SituacaoTarefa { get; set; }
        public virtual ICollection<HistoricoTarefa> HistoricoTarefa { get; set; }
    }
}
