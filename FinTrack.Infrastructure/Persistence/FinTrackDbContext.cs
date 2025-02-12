using FinTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.Infrastructure.Persistence
{
    public class FinTrackDbContext : DbContext
    {
        public FinTrackDbContext(DbContextOptions<FinTrackDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Receive>(e =>
            {
                e.HasKey(R => R.Id);

                e.HasOne(R => R.Balance)
                .WithMany(B => B.Receives)
                .HasForeignKey(R => R.IdBalance)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Balance>(e =>
            {
                e.HasKey(b => b.Id);

                e.HasOne(b => b.User)
                .WithMany(u => u.Balances)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Cost>(e =>
            {
                e.HasKey(C => C.Id);
                e.HasOne(C=>C.Balance).WithMany(B=>B.Costs)
                .HasForeignKey(C => C.IdBalance)
                .OnDelete(DeleteBehavior.Restrict);
            });
            
            base.OnModelCreating(builder);
        }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Receive> Receives { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
