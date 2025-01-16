using RestApiRoskilde.Managers;

namespace RestApiRoskilde.Models
{
    public class Borger
    {
        //public int ID { get; set; }
        //public string Navn { get; set; }
        //public string Tlf { get; set; }
        public BorgerOplysninger borgerOplysninger { get; set; }

        public List<BorgerRegistrering> BorgerRegistreringer { get; set; }
        public List<BorgerPause> BorgerPauser { get; set; }
        //gør notelisten nullable
        public List<BorgerNote> borgerNoter { get; set; }

        //hver gang jeg opretter et nyt borger obj. oprettes en liste af regi, pauser og af noter
        public Borger() 
        {
            BorgerRegistreringer = new List<BorgerRegistrering>();
            BorgerPauser = new List<BorgerPause>();
            borgerNoter = new List<BorgerNote>();
        }
        //Ændret til en liste af borger noter

    }
}
