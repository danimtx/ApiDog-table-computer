using ApiDog_table_computer.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDog_table_computer.Context
{
    public class AplicationBDContext : DbContext
    {
        public AplicationBDContext(DbContextOptions options) : base(options)
        {   
        }
        public DbSet<Computer> Computers { get; set; }
    }
}
