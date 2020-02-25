using System;
using System.Collections.Generic;
using System.Data.Entity;//adding nuget entity framework allowed us to reference this
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class RestaurantDbContext:DbContext
    {
        public RestaurantDbContext():base("DefaultConnection")//"defaultConnection" is from webconfig connection string "name"
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }//creating a property of the dbcontext that is a 
        //database set containing instances of the Restaurant class
        //dbcontext is like a staging area to send a bunch of changes to before saving to database
    }
}