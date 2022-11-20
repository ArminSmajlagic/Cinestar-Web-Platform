using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Modeli.AuthModeli;
using Servisi.IServisi;


namespace Cinestar_WBE_API.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Route("getToken")]
        [HttpGet]
        public async Task<TokenResponse> GetToken(string scope)
        {
            return await authService.GetToken(scope);
        }

        [HttpPost]
        [Route("login")]
        public LoginRespons Login([FromBody] LoginRequest req)
        {
            return authService.Login(req);
        }

        [HttpPost]
        [Route("login/management")]
        public LoginRespons LoginManagement([FromBody] LoginRequest req)
        {
            return authService.LoginManagement(req);
        }

        [HttpPost]
        [Route("registration")]
        public string Registration([FromBody] RegisterRequest req)
        {
            return authService.Register(req);
        }

        [HttpPost]
        [Route("confirmMail")]
        public async Task<string> ConfirmMail([FromBody] ConfirmationRequest req)
        {
            return await authService.ConfirmUser(req);
        }
    }
}
