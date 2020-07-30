using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> opt) : base(opt) { }

        // DB Sets
        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
