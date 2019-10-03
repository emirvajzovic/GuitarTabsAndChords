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

        public DbSet<Albums> Albums { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<NotationCorrections> NotationCorrections { get; set; }
        public DbSet<Notations> Notations { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
