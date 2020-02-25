using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        [Key]//annotations inside [] apply to next object in the code - Key makes it the primary key, Required makes the prop a required field
        public int Id { get; set; }//automatically the primary key because it is the first property in the code - unless we designate a primary key (Key annotation)

        [Required]
        public string Style { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,5)]
        public double Rating { get; set; }

        [Required]
        [Range(1,5)]//gives DollarSigns a min and max value of 1-5
        public int DollarSigns { get; set; }
    }
}