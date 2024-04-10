using RestApiRoskilde.Models;

namespace RestApiRoskilde.Managers
{
    public class BorgerManager
    {
        //autoincrement - static?
        private static int _nextId = 0;

        //En slags FK?
        //private static List<BorgerNote> _borgerNoteListe = new List<BorgerNote>();
        //private static List<BorgerRegistrering> _borgerRegiListe = new List<BorgerRegistrering>();

        //liste med borgers tlf nr
        private static List<Borger> _borgerListe = new List<Borger>()
        {
            new Borger { ID = _nextId++, Navn= "Klaus Jensen", Tlf = "33225511", DatoTid = DateTime.Now,},
            new Borger { ID = _nextId++, Navn="Lotte Bjerg", Tlf = "44558877", DatoTid = DateTime.Now},
            new Borger { ID = _nextId++, Navn="Jens Hansen", Tlf = "24578199", DatoTid = DateTime.Now},
        };

        private const string LogFilePath = "login_log.txt";

        public IEnumerable<Borger> GetAll() 
        { 
            //kopi af listen
            List<Borger> result = new List<Borger>(_borgerListe);
            return result;
        }
        //get borger på deres ID
        public Borger GetByID(int id)
        {
            return _borgerListe.Find(b => b.ID == id);
        }
        //find en borger via. deres tlf
        public Borger GetByTlf(string tlf)
        {
            return _borgerListe.Find(t => t.Tlf == tlf);
        }
        //Opret en ny borger
        public Borger OpretBorger(Borger borger)
        {
            borger.ID = _nextId;
            _borgerListe.Add(borger);
            return borger;
        }

        //statestik over hvor mange gange personen har holdt pause 
        //i løbet af dag/uge
        //statestik ivolvere at tracke user log in i DB/liste
       //loginManager
       //holder handler metoderne til log logins, 
       //loglogin: får/opretter logins på det bestemte tlf nr.
       //getlogincount: henter de logins der tælles op
        //public void LogTheLogIn(string logTlf)
        //{
        //    //handles log på det tilføjede tlf nr
        //    _borgerListe.Add(new Borger { ID = _nextId++, Tlf = logTlf, DateAndTime = DateTime.UtcNow });
        //}
        //public int GetTheLoginCount(string logTlf)
        //{
        //    //handles at hente de logs der er tællet op
        //    return _borgerListe.Count(t=>t.Tlf == logTlf);
        //}

    }
}
