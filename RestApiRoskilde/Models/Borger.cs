using RestApiRoskilde.Managers;

namespace RestApiRoskilde.Models
{
    public class Borger
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
        public List<BorgerRegistrering> BorgerRegistreringer { get; set; }
        //hver gang jeg opretter et nyt borger obj. oprettes en liste af regi.
        public Borger() 
        {
            BorgerRegistreringer = new List<BorgerRegistrering>();
        }
        //Ændret til en liste af borger noter
        public List<BorgerNote> borgerNoter { get; set; }

    }
}
