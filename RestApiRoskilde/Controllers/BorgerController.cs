using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
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
        private BorgerManager _managerBorger = new();
        private BorgerNoteManager _managerNoteBorger = new();
        //private BorgerNoteManager _managerBorgerNote = new();
        //private BorgerRegiManager _registreringManager = new();

        //get all borgere
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Borger>> Get()
        {
            IEnumerable<Borger> result = _managerBorger.GetAllBorger();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // GET api/<AdminController>/5
        //[HttpGet("tlf/{tlf}")]
        //public ActionResult<Borger> Get(string tlf)
        //{
        //    Borger result = _managerBorger.GetByTlfBorger(tlf);
        //    if (result == null)
        //    {
        //        return NotFound("Der findes ingen borger med dette tlf nr!");
        //    }
        //    return Ok(result);
        //}
        //get borger by id
        [HttpGet("{id}")]
        public ActionResult<Borger> Get(int id)
        {
            return _managerBorger.GetByIDBorger(id);
        }
        [HttpPost]
        public ActionResult<Borger> Post([FromBody] Borger opretBorger)
        {
            Borger opret = _managerBorger.OpretBorger(opretBorger);
            if (opret == null)
            {
                return null;
            }
            //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
            return Created($"/api/borger/{opretBorger.ID}", opret);

        }
        /// <summary>
        /// ////BORGER REGISTRERINGER
        /// </summary>
        /// <param borgerID></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{borgerID}/BorgerRegistreringer")]
        public ActionResult<IEnumerable<BorgerRegistrering>> GetAll(int borgerID)
        {
            IEnumerable<BorgerRegistrering> result = _managerBorger.GetAllRegi(borgerID);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpPost("{borgerID}/BorgerRegistreringer")]
        public ActionResult<BorgerRegistrering> Post([FromBody] BorgerRegistrering opretBorgerRegi, int borgerID)
        {
            _managerBorger.GetByIDBorger(borgerID);
            BorgerRegistrering opret = _managerBorger.OpretRegi(opretBorgerRegi, borgerID);
            if (opret == null)
            {
                return null;
            }
            //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
            return NoContent();
        }

        /// <summary>
        /////BORGER PAUSER///
        /// </summary>
        /// <returns></returns>
        //[HttpGet("BorgerPauser")]
        //public ActionResult<IEnumerable<BorgerPause>> GetAll()
        //{
        //    IEnumerable<BorgerPause> result = _managerBorger.GetAllPauser();
        //    if (result.Count() == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        //[HttpPost("BorgerPauser")]
        //public ActionResult<BorgerPause> Post([FromBody] BorgerPause borgerPause, int borgerID)
        //{
        //    _managerBorger.GetAllPauser();
        //    if (borgerPause == null)
        //    {
        //        return null;
        //    }
        //    return NoContent();
        //}
        /// <summary>
        /// /BORGER NOTER
        /// </summary>
        /// <param name="borgerID"></param>
        /// <returns></returns>
        //get all borgernote /ændre route
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{borgerID}/BorgerNoter")]
        public ActionResult<IEnumerable<BorgerNote>> GetAllNoter(int borgerID)
        {
            //Borger borger = _managerBorger.GetByIDBorger(borgerID);
            //på borgerne nu, er der noter
            IEnumerable<BorgerNote> result = _managerNoteBorger.GetAllNoter(borgerID);
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //Virker ikke
        //Note om borger der postes på den samme side
        // POST api/<AdminController>
        [HttpPost("{borgerID}/BorgerNoter")]
        public ActionResult<BorgerNote> Post([FromBody] BorgerNote borgerNote, int borgerID)
        {
            //finde borgeren - hver gang, med som parameter hver gang
            //Borger borger = _managerBorger.GetByIDBorger(borgerID);
            //nu vil jeg have fat i borgerens borgernotemanager, og opretnoten - på borgeren med det ID som jeg indtaster, der er derfor et lag mere
            BorgerNote opretNote = _managerNoteBorger.OpretNote(borgerNote, borgerID);
            if (opretNote == null)
            {
                return null;
            }
            //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
            return NoContent();
            //return Created($"/api/borger/{opretNote.ID = borger.ID}", opretNote);
        }

        //"LOGIN" api/<AdminController>/5
        //If you need to return a status code of 403 (Forbidden)
        //in case the Borger object is null, returns a Forbid Result with a message.
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("{borgerTlfExists}")]
        public ActionResult<Borger> GetByTlf(string tlf)
        {
            //igang - 
            Borger? borger = _managerBorger.GetBorgerByTlf(tlf);
            if (borger == null)
            {
                borger = _managerBorger.CheckIfBorgerExists(tlf);
                //return Forbid("Borger eksistere allerede" + borger);
            }
            return Ok(borger);
        }
    }
}
