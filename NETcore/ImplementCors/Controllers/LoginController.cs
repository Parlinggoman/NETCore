using ImplementCors.Base.Controllers;
using ImplementCors.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETcore.Models;
using NETcore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementCors.Controllers
{
    //[Route("[controller]")]

    public class LoginController : BaseController<Account, LoginRepository, string>
    {

        private readonly LoginRepository loginRepository;
        public LoginController(LoginRepository loginRepository) : base(loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        [HttpPost("LoginCek")]
        public async Task<IActionResult> Auth(string Email, string Password)
        {
            var login = new LoginVM { Email = Email, Password = Password };
            var jwtToken = await loginRepository.Auth(login);
            var token = jwtToken.Token;

            if (token == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", token);
            //HttpContext.Session.SetString("Name", jwtHandler.GetName(token));
            HttpContext.Session.SetString("ProfilePicture", "assets/img/theme/user.png");

            return RedirectToAction("index", "Home");
        }
        //[HttpGet("Login")]
        [Authorize]
        [HttpGet("Logout/")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
        //[httpget("login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
