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
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api", "dc7f343ff9de4e6655da753254190d6b-c9270c97-47cfb0ff")
            };

            RestRequest Request = new RestRequest
            {
                Resource = "{domain}/messages",
                Method = Method.POST,
            };

            Request.AddParameter("domain", "giodev.cf", ParameterType.UrlSegment);
            Request.AddParameter("from", "Quadros KanBan <naoresponda@quadroskanban.giodev.cf>");
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
