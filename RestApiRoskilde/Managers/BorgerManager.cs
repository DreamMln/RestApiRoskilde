using Microsoft.AspNetCore.Mvc.Formatters;
using RestApiRoskilde.Models;
using System.Globalization;

namespace RestApiRoskilde.Managers
{
    public class BorgerManager
    {
        //autoincrement - static?
        private static int _nextId = 0;

        //liste med borgere
        private static List<Borger> _borgerListe = new List<Borger>()
        {
            new Borger {
                ID = _nextId++,
                Navn= "Klaus Jensen",
                Tlf = "33225511",
                BorgerRegistreringer = new List<BorgerRegistrering>()
                {
                    new BorgerRegistrering() 
                    { 
                        Ind = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                    {
                            new BorgerPause() {
                                PauseStart = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                                PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                            }
                     },
                borgerNoter = new List<BorgerNote>
                {
                    new BorgerNote
                    {
                        NoteOmBorger = "Her er der en note om klaus",
                        DatoTid = DateTime.Now.AddHours(-3.05).ToString("dddd, dd MMMM yyyy HH:mm:ss")
                    }
                }
            },
             new Borger {
                ID = _nextId++,
                Navn= "Viola Nielsen",
                Tlf = "45731524",
                BorgerRegistreringer = new List<BorgerRegistrering>()
                {
                    new BorgerRegistrering()
                    {
                        Ind = DateTime.Now.AddHours(-5).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                        {
                            new BorgerPause() {
                                PauseStart = DateTime.Now.AddHours(-4).ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                                PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                            }
                        },
                borgerNoter = new List<BorgerNote>
                {
                    new BorgerNote
                    {
                        NoteOmBorger = "Her er der en note om viola",
                        DatoTid = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                    }
                }
            },
            new Borger {
                ID = _nextId++,
                Navn= "Laura Hansen",
                Tlf = "54847548",
                BorgerRegistreringer = new List<BorgerRegistrering>() 
                { 
                    new BorgerRegistrering() 
                    { 
                        Ind = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"), 
                        Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        
                    }
                },
                BorgerPauser = new List<BorgerPause>()
                        {
                            new BorgerPause()
                            {
                                PauseStart = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                                PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
    }
                        },
                borgerNoter = new List<BorgerNote>  
                {
                    new BorgerNote
                    { 
                        NoteOmBorger = "Her er der endnu en note om laura",
                        DatoTid = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss")
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
            Borger borger = _borgerListe.Find(b => b.ID == id);
            return borger;
        }
        
        //Opret en ny borger
        public Borger OpretBorger(Borger borger)
        {
            borger.ID = _nextId++;
            _borgerListe.Add(borger);
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
            //opretReg.Ind = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            //opretReg.Ud = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            borger.BorgerRegistreringer.Add(opretReg);
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
            Borger borger = GetByIDBorger(id);
            if (opretPause == null)
            {
                return null;
            }
            //opretPause.PauseStart = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            //opretPause.PauseSlut = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            borger.BorgerPauser.Add(opretPause);
            return opretPause;
        }
        public Borger? GetBorgerByTlf(string tlf)
        {
            // Find the Borger object in the list based on the telephone number
            return _borgerListe.Find(b => b.Tlf == tlf);
        }
        //kan ikke være null
        public Borger CheckIfBorgerExists(string tlf)
        {
            // Check if a Borger object exists for the given telephone number
            Borger? borger = GetBorgerByTlf(tlf);
            // If Borger does not exist, create a new one with the provided telephone number
            if (borger == null)
            {
               borger = OpretBorger(new Borger { Tlf = tlf });
            }
            return borger;
        }
    }
}
