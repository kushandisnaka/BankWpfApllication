using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bank2
{
     public class BankDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tempPath = Environment.GetEnvironmentVariable("TEMP")!;
            var dbPath = Path.Combine(tempPath, "users.db");
            Console.WriteLine(dbPath);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
