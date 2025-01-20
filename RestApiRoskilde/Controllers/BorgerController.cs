using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
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
        //private BorgerManager _managerBorger = new();
        //private BorgerNoteManager _managerNoteBorger = new();

        //Ny reference
        private BorgerDBManager _borgerDB;
        //her sættes DB på, derfor ændres new(); til DP Inj.
        public BorgerController(BorgerDBManager borgerDBManager)
        {
            _borgerDB = borgerDBManager;
        }

        //GET ALL borgere
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<BorgerOplysninger>> Get()
        {
            IEnumerable<BorgerOplysninger> result = _borgerDB.GetAllB();
            if (!result.Any())
            {
               return NotFound();
            }
            return Ok(result);
        }
        //GET by id
        [HttpGet("{id}")]
        public ActionResult<BorgerOplysninger> Get(int id)
        {
            return _borgerDB.GetByIDBorger(id);
        }
        //POST opret borgere
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<BorgerOplysninger> Post([FromBody] BorgerOplysninger addBorger)
        {
            BorgerOplysninger result = _borgerDB.OpretBorgerDB(addBorger);
            if (result == null)
            {
                return NoContent();
            }
            //ellers så fortæller den at her kan du hente den actor
            //viser vejen, her med url'en:
            return Created($"/api/borger/{result.ID}", result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // DELETE api/<BorgerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            BorgerOplysninger borgerRemove = _borgerDB.SletBorgerDB(id);
            if (borgerRemove == null)
            {
                return NotFound("There is no borger, with id " + id);
            }
            return Ok(borgerRemove);
        }
        //public ActionResult<Borger> Post([FromBody] Borger opretBorger)
        //{
        //    Borger opret = _borgerDB.OpretBorger(opretBorger);
        //    if (opret == null)
        //    {
        //        return NoContent();
        //    }
        //    //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
        //    return Created($"/api/borger/{opretBorger.ID}", opret);

        //}
        /// <summary>
        /// ////BORGER REGISTRERINGER///
        /// </summary>
        /// <param borgerID></param>
        /// <returns></returns>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[HttpGet("{borgerID}/BorgerRegistreringer")]
        //public ActionResult<IEnumerable<BorgerRegistrering>> GetAll(int borgerID)
        //{
        //    IEnumerable<BorgerRegistrering> result = _managerBorger.GetAllRegi(borgerID);
        //    if (result.Count() == 0)
        //    {
        //        //listen er tom
        //        return NoContent();
        //    }
        //    //ellers returner listen med borger registreringer
        //    return Ok(result);
        //}
        

        /// <summary>
        /////BORGER PAUSER///
        /// </summary>
        /// <returns></returns>
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet("{borgerID}/BorgerPauser")]
        //public ActionResult<IEnumerable<BorgerPause>> GetAllP(int borgerID)
        //{
        //    IEnumerable<BorgerPause> result = _managerBorger.GetAllPauser(borgerID);
        //    if (result.Count() == 0)
        //    {
        //        //listen er tom
        //        return NoContent();
        //    }
        //    //ellers returner listen med borger pauser
        //    return Ok(result);
        //}
       

        /// <summary>
        ////BORGER NOTER///
        /// </summary>
        /// <param name="borgerID"></param>
        /// <returns></returns>
        //get all borgernote /ændre route
        // GET: api/<AdminController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{BorgerID}/BorgerNoter")]
        public ActionResult<IEnumerable<BorgerNote>> GetAllNoter(int BorgerID)
        {
            //Borger borger = _managerBorger.GetByIDBorger(borgerID);
            //på borgerne nu, er der noter
            IEnumerable<BorgerNote> result = _borgerDB.GetAllNoterByIDDB(BorgerID);
            if (result.Count() == 0)
            {
                //listen er tom
                return NoContent();
            }
            //ellers returner listen med borger noter
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{BorgerID}/BorgerOpgaver")]
        public ActionResult<IEnumerable<BorgerOpgave>> GetAllArbejdsOpgaver(int BorgerID)
        {
            IEnumerable<BorgerOpgave> result = _borgerDB.GetAllOpgaverByIDDB(BorgerID);
            if (result.Count() == 0)
            {
                //listen er tom
                return NoContent();
            }
            //ellers returner listen med borger noter
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{BorgerID}/BorgerPauser")]
        public ActionResult<IEnumerable<BorgerOpgave>> GetAllPauser(int BorgerID)
        {
            IEnumerable<BorgerPause> result = _borgerDB.GetAllPauseByIDDB(BorgerID);
            if (result.Count() == 0)
            {
                //listen er tom
                return NoContent();
            }
            //ellers returner listen med borger pauser
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("{borgerID}/BorgerPauser")]
        public ActionResult<BorgerPause> Post([FromBody] BorgerPause borgerPause, int borgerID)
        {
            BorgerPause opretPause = _borgerDB.OpretPauseDB(borgerPause, borgerID);
            if (opretPause == null)
            {
                return BadRequest("OpretPause er null!");
            }
            //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{BorgerID}/BorgerRegistreringer")]
        public ActionResult<IEnumerable<BorgerRegistrering>> GetAllRegi(int BorgerID)
        {
            IEnumerable<BorgerRegistrering> result = _borgerDB.GetAllRegiByIDDB(BorgerID);
            if (result.Count() == 0)
            {
                //listen er tom
                return NoContent();
            }
            //ellers returner listen med borger pauser
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("{borgerID}/BorgerRegistreringer")]
        public ActionResult<BorgerRegistrering> Post([FromBody] BorgerRegistrering opretBorgerRegi, int borgerID)
        {
            //_managerBorger.GetByIDBorger(borgerID);
            BorgerRegistrering opret = _borgerDB.OpretRegiDB(opretBorgerRegi, borgerID);
            if (opret == null)
            {
                return BadRequest("OpretRegi er null!");
            }
            //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
            return NoContent();
        }
        ////Note om borger der postes på den samme side
        //// POST api/<AdminController>
        //[HttpPost("{borgerID}/BorgerNoter")]
        //public ActionResult<BorgerNote> Post([FromBody] BorgerNote borgerNote, int borgerID)
        //{
        //    //finde borgeren - hver gang, med som parameter i hver metode
        //    //nu vil jeg have fat i borgerens borgernotemanager, og opretnoten -
        //    //på borgeren med det NoteID som jeg indtaster, der er derfor et lag mere
        //    BorgerNote opretNote = _managerNoteBorger.OpretNote(borgerNote, borgerID);
        //    if (opretNote == null)
        //    {
        //        return BadRequest();
        //    }
        //    //location header bliver udfyldt, fordi jeg ikke skal bruge svaret
        //    return NoContent();
        //    //return Created($"/api/borger/{opretNote.NoteID = borger.NoteID}", opretNote);
        //}
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpDelete("{borgerID}/BorgerNoter")]
        //public ActionResult<BorgerNote> Delete([FromQuery] int noteID, int borgerID)
        //{
        //    BorgerNote sletNote = _managerNoteBorger.SletNote(noteID, borgerID);
        //    if (sletNote == null)
        //    { 
        //        return NotFound(); 
        //    }
        //    return Ok(sletNote);
        //}
        /// <summary>
        //// BY TLF (istedet for getbyid) ////
        /// </summary>
        /// <param name="tlf"></param>
        /// <returns></returns>
        [HttpGet("{borgerByTlf}/BorgerTlf")]
        public ActionResult<BorgerOplysninger> Get(string tlf)
        {
            return _borgerDB.GetBorgerByTlf(tlf);
        }

        ////"Check om borgeren eksistere" api/<AdminController>/5
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("{tlf}/BorgerTlf")]
        public ActionResult<BorgerOplysninger> Post(string tlf)
        {
            // kald CheckIfBorgerExists medtoden for at checke eller få oprettet en Borger med tlf
            BorgerOplysninger? opretNyBorgerMedTlf = _borgerDB.CheckIfBorgerExists(tlf);
            if (opretNyBorgerMedTlf == null)
            {
                return BadRequest("Opret Tlf er null - ingenting!");

            }
            return Ok(opretNyBorgerMedTlf);

        }
        ////fra query
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{borgerID}")]
        public ActionResult<BorgerOplysninger> Put(int borgerID, [FromQuery] string navn)
        {
            // Call the CheckIfBorgerExists method to check or create Borger
            BorgerOplysninger? opretBorgerMedNavn = _borgerDB.OpdaterBorgerNavn(navn, borgerID);
            if (opretBorgerMedNavn == null)
            {
                return NotFound("Borger findes ikke!");

            }
            return Ok(opretBorgerMedNavn);

        }
    }
}
