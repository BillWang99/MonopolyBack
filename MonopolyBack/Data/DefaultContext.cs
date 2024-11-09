using Microsoft.EntityFrameworkCore;
using MonopolyBack.Models;

namespace MonopolyBack.Data
{
    public class DefaultContext:DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
           : base(options)
        {
        }

        public DbSet<GameHistory> GameHistory { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<RoundResult> RoundResult { get; set; }
    }
}
