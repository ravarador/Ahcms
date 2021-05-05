using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IAppUserRepository
    {
        AppUser IsAuthorized(AppUser appUserLogin);
        string Register(AppUser registerAppUser);
        IRestResponse ChangePassword(AppUser appUser);
    }
}
