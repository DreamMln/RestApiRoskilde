using Microsoft.EntityFrameworkCore;
using RestApiRoskilde.Models;
using System.Collections.Generic;

namespace RestApiRoskilde.Managers
{
    public class DBConnection : DbContext
    {

        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        { }

        public DbSet<BorgerOplysninger> Borgere { get; set; }
        public DbSet<BorgerNote> Noter { get; set; }
        public DbSet<BorgerOpgave> Opgaver { get; set; }
        public DbSet<BorgerPause> Pauser { get; set; }
        public DbSet<BorgerRegistrering> Registreringer { get; set; }
    }
}