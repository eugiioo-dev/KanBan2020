using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KanBanDev.Util
{
    public class Email
    {
        public static bool EnviarEmail(String Destinatario, String Assunto, String Email)
        {
            RestClient Client = new RestClient
            {
                BaseUrl = new Uri(Geral.ConverterBase64ParaTexto("aHR0cHM6Ly9hcGkubWFpbGd1bi5uZXQvdjM=")),
                Authenticator = new HttpBasicAuthenticator("api", Geral.ConverterBase64ParaTexto("a2V5LWU3OTU3M2M0ODliZGI0ZWQ2NGRlMzNiMzJjZWFjZGY3"))
            };

            RestRequest Request = new RestRequest
            {
                Resource = "{domain}/messages",
                Method = Method.POST,
            };

            Request.AddParameter("domain", Geral.ConverterBase64ParaTexto("Z2lvZGV2LmNm"), ParameterType.UrlSegment);
            Request.AddParameter("from", Geral.ConverterBase64ParaTexto("UXVhZHJvcyBLYW5CYW4gPG5hb3Jlc3BvbmRhQHF1YWRyb3NrYW5iYW4uZ2lvZGV2LmNmPg=="));
            Request.AddParameter("to", Destinatario);
            Request.AddParameter("subject", Assunto);
            Request.AddParameter("html", Email);

            IRestResponse Resposta = Client.Execute(Request);

            if (Resposta.StatusCode == HttpStatusCode.OK && Resposta.Content != null)
            {
                RetornoMailGun Retorno = JsonConvert.DeserializeObject<RetornoMailGun>(Resposta.Content);

                if (Retorno.Message == "Queued. Thank you.")
                {
                    return true;
                }
                else
                {
                    return false;
                }            
            }
            else
            {
                return false;
            }
        }

    }

    public class RetornoMailGun
    {
        public string Message { get; set; }

        public string Id { get; set; }
    }
}
