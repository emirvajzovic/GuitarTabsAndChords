using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WebAPI.Database
{
    public class GuitarTabsContext : DbContext
    {
        public GuitarTabsContext(DbContextOptions options) : base(options)
        {
        }

        protected GuitarTabsContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NEONYZIEE-PC\\NEONYZIEE;Database=GuitarTabs;Trusted_Connection=True;");
            }
        }

        public DbSet<Albums> Albums { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<TabCorrections> TabCorrections { get; set; }
        public DbSet<Tabs> Tabs { get; set; }
        public DbSet<Tunings> Tunings { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
