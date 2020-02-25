using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpPost]
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

        //GET ALL
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);//sending the content along with the ok result
        }

        //GET BY ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if(restaurant is null)
            {
            return NotFound();
            }
            return Ok(restaurant);
        }
        /*public async Task<IHttpActionResult> GetByDollarSigns(int dollarSigns)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(dollarSigns);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }*/

        //PUT (Update)
        [HttpPut]//with this, it showed up as a POST
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant model)
        {
            if(ModelState.IsValid && model != null)
            {
            Restaurant entity = await _context.Restaurants.FindAsync(id);//entity is a name used to reference objects actually 
                //in the database (we are using entity framework)
            
            if(entity != null)
                {
                    entity.Name = model.Name;
                    entity.Rating = model.Rating;
                    entity.Style = model.Style;
                    entity.DollarSigns = model.DollarSigns;

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        //DELETE BY ID
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if(restaurant == null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);

            if(await _context.SaveChangesAsync() == 1)
            {
            return Ok();
            }
            return InternalServerError();
        }
    }
}
