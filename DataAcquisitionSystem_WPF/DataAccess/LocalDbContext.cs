using DataAcquisitionSystem_WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisitionSystem_WPF.DataAccess
{
    public class LocalDbContext:DbContext
    {
        public LocalDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=C:\Config\WpfConfig.db");
        public DbSet<Device> Devices { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
