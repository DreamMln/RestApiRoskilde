using Microsoft.AspNetCore.Mvc;
using RestApiRoskilde.Managers;
using RestApiRoskilde.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiRoskilde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorgerController : ControllerBase
    {
        //refencer til manager classes - hvorfor new på??
        private BorgerManager _managerBorgerInfo = new();
        private BorgerNoteManager _managerBorgerNote = new();
        private BorgerRegiManager _registreringManager = new();

        //get all borgere
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Borger>> Get()
        {
            IEnumerable<Borger> result = _managerBorgerInfo.GetAll();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<AdminController>/5
        [HttpGet("tlf/{tlf}")]
        public ActionResult<Borger> Get(string tlf)
        {
            Borger result = _managerBorgerInfo.GetByTlf(tlf);
            if (result == null)
            {
                return NotFound("Der findes ingen borger med dette tlf nr!");
            }
            return Ok(result);
        }
        //get borger by id
        [HttpGet("{id}")]
        public ActionResult<Borger> Get(int id)
        {
            return _managerBorgerInfo.GetByID(id);
        }
        //BORGER REGISTRERINGER
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("BorgerRegistreringer")]
        public ActionResult<IEnumerable<BorgerRegistrering>> GetAllB()
        {
            IEnumerable<BorgerRegistrering> result = _registreringManager.GetAll();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //get borger registereinger by id
        [HttpGet("BorgerRegistreringer/{id}")]
        public ActionResult<BorgerRegistrering> GetAllR(int id)
        {
            return _registreringManager.GetByIDRegistering(id);
        }

        //BORGER NOTER
        //get all borgernote /ændre route
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("BorgerNoter")]
        public ActionResult<IEnumerable<BorgerNote>> GetAllN()
        {
            IEnumerable<BorgerNote> result = _managerBorgerNote.GetAllNoter();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //Note om borger der postes på den samme side
        // POST api/<AdminController>
        [HttpPost("BorgerNoter")]
        public ActionResult<BorgerNote> Post([FromBody] BorgerNote borgerNote)
        {
            BorgerNote result = _managerBorgerNote.OpretBorgerNote(borgerNote);
            if (result == null)
            {
                return null;
            }
            return Created($"/api/borgerInfo/{result.ID}", result);
        }

        // PUT api/<AdminController>/5
        [HttpPut("BorgerNoter/{id}")]
        public ActionResult<BorgerNote> Put(int id, [FromBody] BorgerNote note)
        {
            try
            {
                BorgerNote opdaterBorgerNote = _managerBorgerNote.RedigerBorgerNote(id, note);
                if (opdaterBorgerNote == null)
                {
                    return NotFound();
                }
                return Ok(opdaterBorgerNote);
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) 
            { 
                return BadRequest($"Der er en fejl! {ex.Message}");
            }
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
