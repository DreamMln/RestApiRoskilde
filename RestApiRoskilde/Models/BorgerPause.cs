using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerPause
    {
        [Key]
        public int PauseID { get; set; }
        public DateTime? PauseStart { get; set; }
        public DateTime? PauseSlut { get; set; }
        public int ID { get; internal set; }


    }
}
