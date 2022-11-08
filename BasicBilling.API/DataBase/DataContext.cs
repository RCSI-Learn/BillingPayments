using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.API.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}