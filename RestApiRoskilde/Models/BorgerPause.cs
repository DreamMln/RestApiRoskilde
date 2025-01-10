using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerPause
    {
        [Key]
        public int PauseID { get; set; }
        public string? PauseStart { get; set; }
        public string? PauseSlut { get; set; }

    }
}
