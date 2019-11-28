using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Library.Domain.Entities;


namespace Library.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publishing> Publishings { get; set; }
        public DbSet<CatalogOrder> Orders { get; set; }

        public CatalogDbContext() : base("Default") { }
    }
}
