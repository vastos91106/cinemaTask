using System.Collections.Generic;
using System.Configuration;
using System.Net;
using RestSharp;

namespace Client
{
    public class Service
    {
        RestClient Client => new RestClient(ConfigurationManager.AppSettings["ApiUrl"]);

        public Responce<T> Get<T>(string url) where T : new()
        {
            var request = new RestRequest(url, Method.GET);
            var data = Client.Execute<T>(request);

            var responce = new Responce<T>()
            {
                StatusCode = data.StatusCode,
                Content = data.Data
            };

            return responce;
        }

        public Responce<dynamic> Post<X>(string url, X data)
        {
            var request = new RestRequest("order", Method.POST);
            var json = request.JsonSerializer.Serialize(data);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            var res = Client.Execute<dynamic>(request);

            var responce = new Responce<dynamic>()
            {
                StatusCode = res.StatusCode,
                Content = res.Data
            };

            return responce;
        }
    }

    public class Responce<T>
    {
        public HttpStatusCode StatusCode;

        public T Content;
    }
}
