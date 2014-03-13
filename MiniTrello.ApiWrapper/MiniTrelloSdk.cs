using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTrello.Domain.DataObjects;
using MiniTrello.Domain.Entities;
using RestSharp;

namespace MiniTrello.ApiWrapper
{
    public class MiniTrelloSdk
    {
        private static RestRequest InitRequest(string resource, Method method,object payload)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(payload);
            return request;
        }

        public static AuthenticationModel Login(AccountLoginModel loginModel)
        {
                var client = new RestClient(BaseUrl);
                var request = InitRequest("/login", Method.POST, loginModel);
                IRestResponse<AuthenticationModel> response = client.Execute<AuthenticationModel>(request);
                ConfigurationManager.AppSettings["accessToken"] = response.Data.Token;
                return response.Data;
        }

        private static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["baseUrl"]; }
        }

        public static List<OrganizationModel> GetOrganization()
        {

            return null;
        } 

        
    }
}
