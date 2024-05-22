using RestApiRoskilde.Models;

namespace RestApiRoskilde.Managers
{
    public class BorgerNoteManager
    {
        private static int _autoID = 1;

        public BorgerManager _borgerManager = new BorgerManager();

        public IEnumerable<BorgerNote> GetAllNoter(int id)
        {
            Borger borger = _borgerManager.GetByIDBorger(id);
            if (borger == null)
            {
                return null;
            }
            //ellers tage en kopi af listen
            List<BorgerNote> result = new List<BorgerNote>(borger.borgerNoter);
            return result;
        }
        public BorgerNote OpretNote(BorgerNote opretNote, int id)
        {
            Borger borger = _borgerManager.GetByIDBorger(id);
            opretNote.NoteID = _autoID++;
            borger.borgerNoter.Add(opretNote);
            return opretNote;   
        }
        public BorgerNote SletNote(int noteID, int borgerID)
        {
            // modtager Borger obj. by ID
            Borger borger = _borgerManager.GetByIDBorger(borgerID);
            // hvis Borger er null, return null
            if (borger == null)
            {
                return null;
            }
            //find noten der skal slettes, i borgernoterlisten, via. dens NoteID
            BorgerNote noteSlettes = borger.borgerNoter.Find(note => note.NoteID == noteID);
            // hvis noten er fundet, slet den fra listen
            if(noteSlettes != null)
            {
                borger.borgerNoter.Remove(noteSlettes);
            }
            //return den slettede note
            return noteSlettes;
        }
    }
}
