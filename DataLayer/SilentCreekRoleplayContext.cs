using Microsoft.EntityFrameworkCore;
using SilentCreekRoleplay.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilentCreekRoleplay.DataLayer
{
    public  class SilentCreekRoleplayContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { // Configure your connection
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=davis-pc\sqlexpress;Database=SilentCreekRoleplay;Trusted_Connection=True;");
            // This is a sample using Microsoft SQL Server. For MySQL, install a provider and use UseMySql instead of SqlServer.
        }
    }
}
