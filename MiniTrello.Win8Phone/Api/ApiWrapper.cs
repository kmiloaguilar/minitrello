using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MiniTrello.Win8Phone.Models;
using Newtonsoft.Json;

namespace MiniTrello.Win8Phone.Api
{
    public class ApiWrapper
    {

        //private static RestRequest InitRequest(string resource, Method method, object payload)
        //{
        //    var request = new RestRequest(resource, method);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddBody(payload);
        //    return request;
        //}

        public static async Task<AuthenticationModel> Login(AccountLoginModel loginModel)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:1416");
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post,"/login");
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(loginModel));
            HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
            httpResponse.EnsureSuccessStatusCode();
            var data = await httpResponse.Content.ReadAsStringAsync();
            var authModel = JsonConvert.DeserializeObject<AuthenticationModel>(data);
            //var request = InitRequest("/login", Method.POST, loginModel);
            //IRestResponse<AuthenticationModel> response = client.Execute<AuthenticationModel>(request);
            //ConfigurationManager.AppSettings["accessToken"] = response.Data.Token;
            //return response.Data;
            return null;
        }
    }
}
