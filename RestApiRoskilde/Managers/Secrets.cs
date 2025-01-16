using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace RestApiRoskilde.Managers
{
    public class Secrets
    {
        //local DB
        public static readonly string ConnectionString =
        //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RosKommune;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = MyDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
    }
}
