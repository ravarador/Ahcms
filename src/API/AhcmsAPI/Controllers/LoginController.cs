using AhcmsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AhcmsContext _ahcmsContext;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, AhcmsContext ahcmsContext)
        {
            _logger = logger;
            _ahcmsContext = ahcmsContext;
        }

        [HttpPost]
        [Route("Authorize")]
        public ActionResult Authorize(AppUser loginAppUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var appUser = _ahcmsContext.AppUsers.Where(a => a.Username == loginAppUser.Username && a.Password == loginAppUser.Password).SingleOrDefault();

            return Ok(appUser);
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody] AppUser registerAppUser)
        {
            if (_ahcmsContext.AppUsers.Where(a => a.Username == registerAppUser.Username).Any())
            {
                return Conflict("Username already registered");
            }
            else
            {
                _ahcmsContext.AppUsers.Add(registerAppUser);
                _ahcmsContext.SaveChanges();
                return Ok("Registration successful");

            }
        }

        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword([FromBody] AppUser appUser)
        {
            var appUserToUpdate = _ahcmsContext.AppUsers.Where(a => a.Id == appUser.Id).SingleOrDefault();
            appUserToUpdate.Password = appUser.Password;

            return Ok(_ahcmsContext.SaveChanges());
        }
    }
}
