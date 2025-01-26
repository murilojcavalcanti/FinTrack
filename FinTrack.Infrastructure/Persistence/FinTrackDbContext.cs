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

        public DbSet<Cost> costs { get; set; }
        public DbSet<Receive> Receives { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }
}
