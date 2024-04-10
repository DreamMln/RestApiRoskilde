using Microsoft.AspNetCore.Mvc;
using RestApiRoskilde.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiRoskilde.Controllers
{
    //denne controller, skal sørge for POST, GET logins
    //henter og poster de tællede logins på et specifikt tlf nr
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BorgerManager _borgerInfoManager;

        //dependency injection
        public LoginController(BorgerManager infoManager)
        {
              _borgerInfoManager = infoManager;
        }
        // GET: api/<LoginController>
        //[HttpGet("login-count/{tlf}")]
        //public IActionResult GetLoginCount(string tlf)
        //{
        //    int loginCount = _borgerInfoManager.GetTheLoginCount(tlf);
        //    return Ok();

        //}
        //// GET api/<LoginController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<LoginController>
        //[HttpPost("login")]
        //public IActionResult Login(string tlf)
        //{
        //    _borgerInfoManager.LogTheLogIn(tlf);
        //    return Ok();
        //}

        // PUT api/<LoginController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
