using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RSAEncriptacionService.Helpers;
using RSAEncriptacionService.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSAEncriptacionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("basic-login")]
        public ActionResult<string> LoginBasic([FromBody] User user)
        {
            var usuarios = configuration.GetSection("Usuarios").Get<User[]>();
            var logged = usuarios.FirstOrDefault(u => u.idUsuario == user.idUsuario && u.contrasenha == user.contrasenha);
            return Ok(logged);

        }

        [HttpPost]
        [Route("rsa-login")]
        public ActionResult<string> LoginRSA([FromBody] User user)
        {
            user.contrasenha = RSAHelper.Decrypt(user.contrasenha);
            var usuarios = configuration.GetSection("Usuarios").Get<User[]>();
            var logged = usuarios.FirstOrDefault(u => u.idUsuario == user.idUsuario && u.contrasenha == user.contrasenha);
            return Ok(logged);
        }


        [HttpPost]
        [Route("rsa-advanced-login")]
        public ActionResult<string> LoginRSAAdvanced([FromBody] RSAUserData userData)
        {
            string userJson = RSAHelper.Decrypt(userData.Data);
            User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userJson);
            var usuarios = configuration.GetSection("Usuarios").Get<User[]>();
            var logged = usuarios.FirstOrDefault(u => u.idUsuario == user.idUsuario && u.contrasenha == user.contrasenha);
            return Ok(logged);
        }
    }
}
