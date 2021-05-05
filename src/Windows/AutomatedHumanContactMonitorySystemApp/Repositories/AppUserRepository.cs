using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly string ApiAddress = Settings.Default.ApiAddress;
        public AppUser IsAuthorized(AppUser appUserLogin)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/login/authorize/", Method.POST);
            request.AddJsonBody(appUserLogin);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var placeId = JsonConvert.DeserializeObject<AppUser>(response.Content);
            return placeId;
        }

        public string Register(AppUser registerAppUser)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/login/register/", Method.POST);
            request.AddJsonBody(registerAppUser);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var message = JsonConvert.DeserializeObject<string>(response.Content);
            return message;
        }

        public IRestResponse ChangePassword(AppUser appUser)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/login/changepassword/", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(appUser);
            var response = client.Execute(request);
            return response;
        }
    }
}
