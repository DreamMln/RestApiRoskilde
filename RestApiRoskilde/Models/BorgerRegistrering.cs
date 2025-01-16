using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerRegistrering
    {
        [Key]

        public int RegiID { get; set; }
        public DateTime? Ind { get; set; }
        public DateTime? Ud { get; set; }
        public int ID { get; internal set; }

    }
}
