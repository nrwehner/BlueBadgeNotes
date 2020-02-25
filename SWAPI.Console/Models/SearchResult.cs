using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI.Models
{
    class SearchResult<T>//T allows us to make a class that works for all possible types of searches - i'm defining a parameter for the class
        //you must define a class to declare this type
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
