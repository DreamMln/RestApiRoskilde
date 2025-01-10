using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerOpgave
    {
        [Key] // Ensure the primary key needs to be defined

        public int BorgerOpgID { get; set; }
        public string BorgerNavn { get; set; }
        public string ArbejdsOpgave { get; set; }
        public string OpgaveBeskrivelse { get; set; }
        public DateTime OpgStart { get; set; }
        public DateTime OpgSlut { get; set; }
        //FK til Borger
        public int ID { get; internal set; }
    }
}
