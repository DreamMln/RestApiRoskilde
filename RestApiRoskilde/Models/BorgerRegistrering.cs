namespace RestApiRoskilde.Models
{
    public class BorgerRegistrering
    {
        public DateTime Ind { get; set; }
        public DateTime Ud { get; set; }
        public List<BorgerPause>? BorgerPauser { get; set; }
    }
}
