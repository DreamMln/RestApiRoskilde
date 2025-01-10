using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerRegistrering
    {
        [Key]

        public int RegiID { get; set; }
        public string? Ind { get; set; }
        public string? Ud { get; set; }
    }
}
