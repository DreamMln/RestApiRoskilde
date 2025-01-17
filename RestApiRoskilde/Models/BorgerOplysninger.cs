using System.ComponentModel.DataAnnotations;

namespace RestApiRoskilde.Models
{
    public class BorgerOplysninger
    {
        [Key]
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Tlf { get; set; }
    }
}