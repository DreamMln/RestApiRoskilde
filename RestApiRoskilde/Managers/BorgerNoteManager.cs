using RestApiRoskilde.Models;

namespace RestApiRoskilde.Managers
{
    public class BorgerNoteManager
    {
        //HVORFOR EN MANAGER TIL BORGERNOTER?
        //DER SKAL LAVES MERE KOMPLEXITET TIL NOTER, REDIGER OG SLET
        //DET GIVER DERFOR MENING AT HAVE EN MANAGER CLASS TIL BORGERNOTER

        public BorgerManager _borgerManager = new BorgerManager();
        //public Borger _borger;
        //autoincrement - static?
        //private static int _nextId = 0;

        //liste med borgers tlf nr
        //private static List<BorgerNote> borgerNoteListe = new List<BorgerNote>()
        //{
        //    new BorgerNote { ID = _nextId++, NoteOmBorger = "Her er der en note", DatoTid = DateTime.Now},
        //    new BorgerNote { ID = _nextId++, NoteOmBorger = "Her er der endnu en note", DatoTid = DateTime.Now},
        //};

        public IEnumerable<BorgerNote> GetAllNoter(int id)
        {
            Borger borger = _borgerManager.GetByIDBorger(id);
            List<BorgerNote> result = new List<BorgerNote>(borger.borgerNoter);
            return result;
        }
        public BorgerNote OpretNote(BorgerNote opretNote, int id)
        {
            Borger borger = _borgerManager.GetByIDBorger(id);
            borger.borgerNoter.Add(opretNote);
            return opretNote;   
        }
        //public BorgerNote RedigerNote(int id, BorgerNote redigerNote)
        //{
        //    BorgerNote eksisterendeBorgerNote = borgerNoteListe.Find(n => n.ID == id);
        //    if (eksisterendeBorgerNote != null)
        //    {
        //        eksisterendeBorgerNote.NoteOmBorger = redigerNote.NoteOmBorger;
        //    }
        //    return eksisterendeBorgerNote;
        //}
    }
}
