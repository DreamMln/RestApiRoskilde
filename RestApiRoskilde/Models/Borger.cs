using RestApiRoskilde.Managers;

namespace RestApiRoskilde.Models
{
    public class Borger
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
        public List<BorgerRegistrering> BorgerRegistreringer { get; set; }
        //Ændret til en liste af borger noter
        public List<BorgerNote> borgerNoter { get; set; }

    }
}
