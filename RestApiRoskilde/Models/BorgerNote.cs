using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerNote
    {
        [Key] // Ensure the primary key needs to be defined

        public int NoteID { get; set; }
        public string NoteOmBorger { get; set; }
        public DateTime DatoTid { get; set; }
        public int ID { get; internal set; }
    }
}
