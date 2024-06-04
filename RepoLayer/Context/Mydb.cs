using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoLayer.Entity;

namespace RepoLayer.Context
{
    public class Mydb: DbContext
    {
        public Mydb(DbContextOptions options):base(options) { }

        public DbSet<Customer>customers { get; set; }
    }
}
