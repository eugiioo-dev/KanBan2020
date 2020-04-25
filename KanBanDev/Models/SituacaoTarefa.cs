using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class SituacaoTarefa
    {
        public SituacaoTarefa()
        {
            HistoricoTarefa = new HashSet<HistoricoTarefa>();
            Tarefa = new HashSet<Tarefa>();
        }

        public int SituacaoTarefaId { get; set; }
        public string SituacaoTarefaDescricao { get; set; }

        public virtual ICollection<HistoricoTarefa> HistoricoTarefa { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
