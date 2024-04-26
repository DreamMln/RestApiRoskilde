using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestApiRoskilde.Managers;
using RestApiRoskilde.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiRoskilde.Controllers
{
    //denne controller, skal sørge for POST, GET logins
    //henter og poster logins på et specifikt tlf nr
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //ref til loginmanager
        private LoginManager _loginManager = new();

        //skal den ikke i en GET istedet for?
        //401 (Unauthorized) status code indicates that the request has not been applied
        //POST api/<LoginController>
        //[HttpPost]
        //public ActionResult Login([FromBody] LoginBorger loginBorger)
        //{
        //    var borger = _loginManager.GetBorgerTlfLogin(loginBorger.Tlf);
        //    if (borger !=null)
        //    {
        //        // Return some user data or a token for authentication
        //        return Ok(new { message = "Du er nu logget ind med dit tlf nr!"});
        //    }
        //    else
        //    {
        //        _loginManager.OpretBorgerLoginAsync(loginBorger.Tlf);
        //        return Ok(new { Message = "Dit Tlf nr blev oprettet i systemet!" });
        //        //return Unauthorized(new { Message = "Dit tlf nr eksistere ikke i systemet!" });
        //        //return Conflict(new { Message = "Dit tlf nr eksistere allerede i systemet!" });
        //    }
        //    //fejlbesked her?
            
        //}

        // GET: api/<LoginController>
        [HttpGet]
        public ActionResult GetLogin()
        {
            IEnumerable<LoginBorger> result = _loginManager.GetAllLogin();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);


        }
    }
}
