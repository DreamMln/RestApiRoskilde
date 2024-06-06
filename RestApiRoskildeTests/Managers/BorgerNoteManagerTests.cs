using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApiRoskilde.Managers;
using RestApiRoskilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RestApiRoskilde.Managers.Tests
{
    [TestClass()]
    public class BorgerNoteManagerTests
    {
        //ref to borgernotemanager - hvor metoderne er
        private static BorgerNoteManager _borgerNoteManager;
        private static BorgerManager _borgerManager;

        //TestInitialize-metoden sikre at alt er korrekt opsat før hver testkørsel.
        //sørger for at BorgerNoteManager og BorgerManager er korrekt initialiserede,
        //og at der er en Borger tilgængelig til testene.
        [TestInitialize]
        public void Setup()
        {
            // Initialize Managers
            _borgerManager = new BorgerManager();
            _borgerNoteManager = new BorgerNoteManager();

            // tilføj et eksempel af borger til BorgerManager
            var borger = new Borger { ID = 1 };
            _borgerManager.OpretBorger(borger);
        }
        [TestMethod()]
        public void GetAllNoterTest()
        {
            // Arrange - borger med ID 1
            int borgerID = 1;

            // Arrange - på borgerID 1
           // int borgerID = 1;
            // Act
            IEnumerable<BorgerNote> borgerNoter = _borgerNoteManager.GetAllNoter(borgerID);
            // Assert
            //resultatet burde ikke være null
            Assert.IsNotNull(borgerNoter);
            //resultatet skal indeholde mindst 1 note på borgerID 1
            Assert.IsTrue(borgerNoter.Any());
            //indeholder præcis 1 noter på BorgerID 1
            Assert.AreEqual(1, borgerNoter.Count()); 
        }

        [TestMethod()]
        public void OpretNoteOgSletDenTest()
        {
            // Arrange - på borgerID 1
            // opret en ny note for borgerID 1, med teksten "HEJ"
            int borgerID = 1;
            var newNote = new BorgerNote { NoteID = 1, NoteOmBorger = "HEJ" };


            // Act - tilføj denne nye note til borgeren med id 1
            BorgerNote result = _borgerNoteManager.OpretNote(newNote, borgerID);

            // Assert
            //resultatet burde ikke være null
            Assert.IsNotNull(result);
            //note indhold, skal være det samme - areequal
            Assert.AreEqual(newNote.NoteOmBorger, result.NoteOmBorger);
            //NoteID burde være 1, da der kun er en note der oprettet
            Assert.AreEqual(1, result.NoteID);

            //hent borger på dens ID, tager borger med borgerID 1 (i denne test),
            //og henter borger obj. forbundet med dette ID, fra manageren
            //det returnerede borger obj, gemmes i var borger
            var borger = _borgerManager.GetByIDBorger(borgerID);
            //først sikres at borger ikke er null, hvis den var null, betyder det at der ikke er fundet et borger obj. med det angivne ID
            Assert.IsNotNull(borger);
            //tjekker om listen borgerNoter i borger obj., indeholder præcis to noter,
            //er præcis 2. Hvis antallet ikke er 2, vil testen fejle
            Assert.AreEqual(2, borger.borgerNoter.Count);
            //den tilføjede note burde matche resultatet -
            //er begge noter tilstede - tjekker i listen BorgerNoter
            //bruger Any til at finde noter med de samme ID'er
            Assert.IsTrue(borger.borgerNoter.Any(note => note.NoteID == 1));
            // Arrange - på borgerID 1

            // Slet Noten igen
            // Act - slet denne nye note til borgeren med id 1
            BorgerNote resultSlet = _borgerNoteManager.SletNote(newNote.NoteID, borgerID);
            // Assert
            //resultatet burde ikke være null
            Assert.IsNotNull(resultSlet);
            //note indhold, skal være det samme - areequal
            Assert.AreEqual(newNote.NoteOmBorger, resultSlet.NoteOmBorger);
            // Sikre at den slettede note er den samme som den forsøgte at blive slettet
            Assert.AreEqual(newNote.NoteID, resultSlet.NoteID); 
           
            // Hent borgeren ved ID
            var borgerSlet = _borgerManager.GetByIDBorger(borgerID);
            // Borgeren burde ikke være null
            Assert.IsNotNull(borgerSlet); 

            // Borgeren burde nu kun have én note
            Assert.AreEqual(1, borgerSlet.borgerNoter.Count);
        }
    }
}