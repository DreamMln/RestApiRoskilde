using System.Security.Claims;

namespace RestApiRoskilde.Models
{
    public class LoginBorger
    {
        public string Tlf { get; set; }

        //public List<Claim> Claims { get; }
        //// til tlf: String.Format("{0:(###) ###-####}", Int64.Parse("8005551212"))
        //public LoginBorger(List<Claim> claims)
        //{
        //    Claims = claims;

        //}
    }
}
