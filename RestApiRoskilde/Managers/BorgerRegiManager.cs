using RestApiRoskilde.Models;

namespace RestApiRoskilde.Managers
{
    public class BorgerRegiManager
    {
        //autoincrement - static?
        private static int _nextId = 0;
        //liste med borgers tlf nr
        private static List<BorgerRegistrering> _borgerRegistreringer = new List<BorgerRegistrering>()
        {
            new BorgerRegistrering { ID = _nextId++, Ind= DateTime.Now, Ud=DateTime.Now, Pause=DateTime.Now},
            new BorgerRegistrering { ID = _nextId++, Ind= DateTime.Now, Ud=DateTime.Now, Pause=DateTime.Now},
            new BorgerRegistrering { ID = _nextId++, Ind= DateTime.Now, Ud=DateTime.Now, Pause=DateTime.Now},
            
        };

        public IEnumerable<BorgerRegistrering> GetAll()
        {
            //kopi af listen
            List<BorgerRegistrering> result = new List<BorgerRegistrering>(_borgerRegistreringer);
            return result;
        }
        //get borger på deres ID
        public BorgerRegistrering GetByIDRegistering(int id)
        {
            return _borgerRegistreringer.Find(r => r.ID == id);
        }
        //Opret en ny registrering
        public BorgerRegistrering OpretRegistering(BorgerRegistrering opretReg)
        {
            opretReg.ID = _nextId;
            _borgerRegistreringer.Add(opretReg);
            return opretReg;
        }
    }
}
