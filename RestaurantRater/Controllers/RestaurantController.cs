using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // POST
        public async Task<IHttpActionResult> PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid && restaurant!=null)
            {
            _context.Restaurants.Add(restaurant);//_context was initialized above - .Restaurants references the dbcontext we set in RestaurantDbContext
            await _context.SaveChangesAsync();//line above added to the dbContext (dbset Restaurants) (snapshot), now we need to save that snapshot to the actual database
            return Ok();
            }
            return BadRequest(ModelState);
        }//as soon as we call this method for the first time, our database will be scaffolded out, up until then, all we have is a dbcontext(stagin area)
    }
}
