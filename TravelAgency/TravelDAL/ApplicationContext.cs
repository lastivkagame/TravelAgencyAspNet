using System;
using System.Data.Entity;
using System.Linq;
using TravelDAL.Entities;

namespace TravelDAL
{
    public class ApplicationContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TravelDAL.ApplicationContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationContext' 
        // connection string in the application configuration file.
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new TourInitializer());
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<ImageForGallary> ImageForGallaries { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}