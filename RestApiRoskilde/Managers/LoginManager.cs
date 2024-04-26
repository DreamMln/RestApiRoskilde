using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RestApiRoskilde.Models;
using System.Net.Http;
using System.Security.Claims;

namespace RestApiRoskilde.Managers
{
    public class LoginManager
    {
        //ER DET DEN RIGTIGE LISTE?
        //JEG SKAL OPRETTE BORGEREN MED TLF TIL
        //LISTEN MED ALLE BORGERNE, DET HER ER LOGINBORGER

        //private static int _nextId = 0;

        //en liste til borger tlf numrene
        private static List<LoginBorger> _borgerLogins = new List<LoginBorger>
        {
            // Initialize listen med nogle hardcoded borgere
            new LoginBorger { Tlf = "33225511" },
            new LoginBorger { Tlf = "54847548" }
        };
        public IEnumerable<LoginBorger> GetAllLogin()
        {
            //kopi af listen
            List<LoginBorger> result = new List<LoginBorger>(_borgerLogins);
            return result;
        }
        //find en borger via. deres tlf nr
        
        public async Task<bool> OpretBorgerLoginAsync(string opretBorgerTlf)
        {
            //hvis brugeren allerede eksistere med tlf nr, returner false
            if (_borgerLogins.Exists(b => b.Tlf == opretBorgerTlf))
            {
                return false; // User already exists
            }
            // ellers opret et borgerlogin til listen med nyt tlf nr.
            _borgerLogins.Add(new LoginBorger { Tlf = opretBorgerTlf });
            //iterere igennem en liste af borgerlogins, tjekker på om
            //opretborgertlf matcher tlf prop, i hvert obj. i listen
            //hvis der findes et match, så oprettes en claim/et krav,
            //en rolle er tildelt borgeren og navnet er tlf nummeret
            //og borger logges ind
            foreach (var b in _borgerLogins) 
            { 
                if (opretBorgerTlf == b.Tlf)
                {
                    //ny liste af claims til borger/user
                    var claims = new List<Claim>
                     {
                         new Claim(ClaimTypes.Role, "user"),
                         new Claim(ClaimTypes.Name, b.Tlf)
                    };
                    //create/opret en claims identity og log borgeren ind
                    var claimsIdentity =
                    new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    //new ClaimsPrincipal(claimsIdentity));

                    //returner true, efter user/borger er blevet logget ind
                    return true;
                }
            }
            // denne return statement burde være unreachable,
            // fordi loop altid skal finde borgerliogin'et
           // hvis den lander her, indikere det at der er en fejltilstand
           return false;
        }
    }
}
