using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Models
{
    public class TripContext : DbContext
    {
        //setting the context's db context options
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        { }

        //getting the dbset for the contacts and categories
        public DbSet<Trip> Trips { get; set; }

        //giving the model creator its context for database creation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trip>().HasData(
            new Trip
            {
                Id = -1,
                Destination = "Disney Land",
                StartDate = System.DateTime.Now,
                EndDate = System.DateTime.Now.AddDays(7),
                Accommodation = "DisneyLand Hotel",
                AccommodationPhone = "714-781-4636",
                AccommodationEmail = "Hotels@DisneyLand.com",
                ThingsToDo = ["Ride the rides", "See the mascots", "Eat food"]
            },
            new Trip
            {
                Id = -2,
                Destination = "Evil Disney Land",
                StartDate = System.DateTime.Now.AddDays(10),
                EndDate = System.DateTime.Now.AddDays(17),
                Accommodation = "Evil DisneyLand Hotel",
                AccommodationPhone = "636-418-7417",
                AccommodationEmail = "Hotels@EvilDisneyLand.com",
                ThingsToDo = ["Ride the evil rides", "See the evil mascots", "Eat evil food"]
            }
        ) ;
        }
    }
}
