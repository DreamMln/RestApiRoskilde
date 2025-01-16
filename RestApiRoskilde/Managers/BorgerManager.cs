using Microsoft.AspNetCore.Mvc.Formatters;
using RestApiRoskilde.Models;
using System.Globalization;

namespace RestApiRoskilde.Managers
{
    public class BorgerManager
    {
        //autoincrement - static?
        private static int _nextId = 0;
        private static int _nextIdRegi = 1;
        private static int _nextIdPause = 1;

        //liste med borgere
        private static List<Borger> _borgerListe = new List<Borger>()
        {
            new Borger {
                //ID = _nextId++,
               // Navn= "Klaus Jensen",
               // Tlf = "33225511",
                BorgerRegistreringer = new List<BorgerRegistrering>()
                {
                    new BorgerRegistrering() 
                    { 
                        Ind = DateTime.Now.AddHours(-4).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                    {
                            new BorgerPause() {

                               // PauseStart = DateTime.Now.AddMinutes(-31).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                               // PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                            }
                     },
                borgerNoter = new List<BorgerNote>
                {
                    new BorgerNote
                    {
                        NoteOmBorger = "Her er der en note om klaus",
                        //DatoTid = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                    }
                }
            },
             new Borger {
               // ID = _nextId++,
               // Navn= "Viola Nielsen",
               // Tlf = "45731524",
                BorgerRegistreringer = new List<BorgerRegistrering>()
                {
                    new BorgerRegistrering()
                    {
                        Ind = DateTime.Now.AddHours(-5).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                        { new BorgerPause() {
                            //    PauseStart = DateTime.Now.AddMinutes(-15).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                             //   PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                        }
                },
                borgerNoter = new List<BorgerNote>
                {
                    new BorgerNote
                    {
                        NoteOmBorger = "Her er der en note om viola",
                       // DatoTid = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                    }
                }
            },
            new Borger {
               // ID = _nextId++,
               // Navn= "Laura Hansen",
               // Tlf = "54847548",
                BorgerRegistreringer = new List<BorgerRegistrering>() 
                { 
                    new BorgerRegistrering() 
                    { 
                        Ind = DateTime.Now.AddHours(-3.05).ToString("dddd, dd MMMM yyyy HH:mm:ss"), 
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                        {
                            new BorgerPause()
                            {
                              //  PauseStart = DateTime.Now.AddMinutes(-12).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                              //  PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
    }
                        },
                borgerNoter = new List<BorgerNote>  
                {
                    new BorgerNote
                    { 
                        NoteOmBorger = "Her er der endnu en note om laura",
                       // DatoTid = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                    }
                },
            }
        };

        public IEnumerable<Borger> GetAllBorger()
        {
            //kopi af listen
            List<Borger> result = new List<Borger>(_borgerListe);
            return result;
        }
        //get borger på deres NoteID
        public Borger GetByIDBorger(int id)
        {
            //Borger borger = _borgerListe.Find(b => b.ID == id);
            //return borger;
            return null;
        }

        //Opret en ny borger
        public Borger OpretBorger(Borger borger)
        {
            //borger.ID = _nextId++;
            //_borgerListe.Add(borger);
            //return borger;
            return null;
        }

        //Opret et navn på borger - det er en update
        public Borger OpdaterBorgerNavn(string navn, int borgerID)
        {
            Borger borger = GetByIDBorger(borgerID);
            if (borger == null)
            {
                return null;
            }
            //opdater borgerens navn
            //borger.Navn = navn;
            return borger;
        }
        //////////////////BORGER REGISTRERINGER///////////
        public IEnumerable<BorgerRegistrering> GetAllRegi(int id)
        {
            //vi forventer at Borger nogle gange er null
            Borger? borger = GetByIDBorger(id);
            if (borger == null)
            {
                return null;
            }
            //en kopi af listen
            List<BorgerRegistrering> result = new List<BorgerRegistrering>(borger.BorgerRegistreringer);
            return result;
        }
        //Opret en ny registrering
        public BorgerRegistrering OpretRegi(BorgerRegistrering opretReg, int id)
        {
            Borger borger = GetByIDBorger(id);
            if (borger == null)
            {
                return null;
            }
            //hvis ikke null
            if (opretReg.Ind != null)
            {
                opretReg.RegiID = _nextIdRegi++;
                borger.BorgerRegistreringer.Add(opretReg);

            }
            //hvis opret regi.ud ikke er null
            else if (opretReg.Ud != null)
            {
                //vil finde en ud regi der ikke har en udregstrering
                BorgerRegistrering udRegi = borger.BorgerRegistreringer.FirstOrDefault(regi => regi.Ud == null);
                //udregi bliver sat til en ud regi
                udRegi.Ud = opretReg.Ud;

            }
            return opretReg;
        }
        //////////////////BORGER PAUSER///////////
        public IEnumerable<BorgerPause> GetAllPauser(int id)
        {
            Borger borger = GetByIDBorger(id);
            if (borger == null)
            {
                return null;
            }
            //kopi af listen
            List<BorgerPause> result = new List<BorgerPause>(borger.BorgerPauser);
            return result;
        }
        public BorgerPause OpretPause(BorgerPause opretPause, int id)
        {
            //opret en pause på borgeren med id
            Borger borger = GetByIDBorger(id);
            //hvis borger er null, returner null
            if (borger == null)
            {
                return null;
            }
            //hvis opret pause.pauseStart, ikke er null
            if (opretPause.PauseStart != null)
            {
                //så opret pause til listen med pauser
                opretPause.PauseID = _nextIdPause++;
                borger.BorgerPauser.Add(opretPause);

            }
            //hvis opret pause slut ikke er null
            else if (opretPause.PauseSlut != null)
            {
                BorgerPause pauseSlut = borger.BorgerPauser.FirstOrDefault(pause => pause.PauseSlut == null);
                //PauseSlut bliver sat til en slut pause
                pauseSlut.PauseSlut = opretPause.PauseSlut;

            }
            return opretPause;
        }
        public Borger? GetBorgerByTlf(string tlf)
        {
            // Find the Borger object in the list based on the telephone number
            //return _borgerListe.Find(b => b.Tlf == tlf);
            return null;
        }
        //kan ikke være null
        public Borger CheckIfBorgerExists(string tlf)
        {
            // Check if a Borger object exists for the given telephone number
            Borger? borger = GetBorgerByTlf(tlf);
            // If Borger does not exist, create a new one with the provided telephone number
            if (borger == null)
            {
               //borger = OpretBorger(new Borger { Tlf = tlf });
            }
            return borger;
        }
    }
}
    

