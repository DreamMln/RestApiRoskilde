namespace RestApiRoskilde.Models
{
    public class Borger
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
        public DateTime DatoTid { get; set; }
        public List<BorgerRegistrering> BorgerRegistreringer { get; set; }
        public List<BorgerNote> BorgerNoter { get; set; }
    }
}
