using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModel.DataProviders.EFs.Core
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<History> Histories { get; set; } = null!;
        public DbSet<Calculation> Calculations { get; set; } = null!;
    }
}
