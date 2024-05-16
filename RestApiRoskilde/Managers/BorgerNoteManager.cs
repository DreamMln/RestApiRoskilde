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
            List<BorgerNote> result = new List<BorgerNote>(borger.borgerNoter);
            return result;
        }
        public BorgerNote OpretNote(BorgerNote opretNote, int id)
        {
            Borger borger = _borgerManager.GetByIDBorger(id);
            opretNote.ID = _autoID++;
            borger.borgerNoter.Add(opretNote);
            return opretNote;   
        }
        public BorgerNote SletNote(int noteID, int borgerID)
        {
            Borger borger = _borgerManager.GetByIDBorger(borgerID);
            if (borger == null)
            {
                return null;
            }
            //find borgernoten med det tildelte id
            //find noten i borgernoterlisten, med dens ID
            BorgerNote noteSlettes = borger.borgerNoter.Find(note => note.ID == noteID);
            //slet noten fra borger obj. liste af noter
            borger.borgerNoter.Remove(noteSlettes);
            return noteSlettes;
        }
    }
}
