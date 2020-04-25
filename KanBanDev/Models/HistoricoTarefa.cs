using System;
using System.Collections.Generic;

namespace KanBanDev.Models
{
    public partial class HistoricoTarefa
    {
        public int HistoricoTarefaId { get; set; }
        public DateTime HistoricoDtCriacao { get; set; }
        public string TarefaTitulo { get; set; }
        public string TarefaDescricao { get; set; }
        public int SituacaoTarefaId { get; set; }
        public int TarefaId { get; set; }

        public virtual SituacaoTarefa SituacaoTarefa { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
