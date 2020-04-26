using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanDev.Util
{
    [Serializable]
    public class Retorno
    {
        public Retorno()
        {
            this.Status = Resultado.NaoDefinido;
        }

        public enum Resultado
        {
            Ok = 0,
            Erro = 1,
            NaoDefinido = -1
        }

        private IEnumerable<ModelError> _Erros;

        public Resultado Status { get; set; }
        public object ParametrosAdicionais { get; set; }

        public IEnumerable<ModelError> Erros
        {
            get
            {
                return this._Erros;
            }

            set
            {
                List<ModelError> ErrosEnviados = ((IEnumerable<ModelError>)value).ToList<ModelError>();
                
                if (ErrosEnviados.Count > 0) 
                    this.Status = Resultado.Erro;

                this._Erros = value;
            }
        }

        public static IEnumerable<ModelError> ExtrairErrosModelState(ModelStateDictionary mState)
        {
            return from erro in mState.Values
                   where erro.Errors.Count > 0
                   select erro.Errors[0];
        }
    }
}
