using RestApiRoskilde.Models;

namespace RestApiRoskilde.Managers
{
    public class BorgerNoteManager
    {
        //autoincrement - static?
        private static int _nextId = 0;
        //liste med borgers tlf nr
        private static List<BorgerNote> _borgerNoteListe = new List<BorgerNote>()
        {
            new BorgerNote { ID = _nextId++, NoteOmBorger = "Her er der en note", DatoTid = DateTime.Now},
            new BorgerNote { ID = _nextId++, NoteOmBorger = "Her er der endnu en note", DatoTid = DateTime.Now},
        };

        public IEnumerable<BorgerNote> GetAllNoter()
        {
            List<BorgerNote> result = new List<BorgerNote>(_borgerNoteListe);
            return result;
        }
        public BorgerNote OpretBorgerNote(BorgerNote opretNote)
        {
            //FK til en borgerinfo
            opretNote.ID = _nextId++;
            _borgerNoteListe.Add(opretNote);
            return opretNote;   
        }
        public BorgerNote RedigerBorgerNote(int id, BorgerNote redigerNote)
        {
            BorgerNote eksisterendeBorgerNote = _borgerNoteListe.Find(n => n.ID == id);
            if (eksisterendeBorgerNote != null)
            {
                eksisterendeBorgerNote.NoteOmBorger = redigerNote.NoteOmBorger;
            }
            return eksisterendeBorgerNote;
        }
    }
}
