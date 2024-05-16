using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace RestApiRoskilde.Models
{
    public class DatoKonvertering
    {
        //Use a Custom Date Type: You can create a 
        //    custom date type in C# to encapsulate 
        //    the logic for date formatting and parsing. 
        //    This can make your code cleaner and 
        //    more maintainable by centralizing date handling logic.
        private DateTime _date;
        public DatoKonvertering(string dateString)
        {
            // Parse the string to DateTime
            _date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public override string ToString()
        {
            // Format DateTime as string
            return _date.ToString("yyyy-MM-dd");
        }
    }
}
