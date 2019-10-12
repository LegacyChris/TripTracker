using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext:DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) 
        {

        }
        public TripContext()
        {

        }
        public DbSet<Trip> Trips { get; set; }
    
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        // //   modelBuilder.Entity<Trip>().HasKey(t => t.TheId);
        //}
    }

    
}
