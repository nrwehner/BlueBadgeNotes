using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            //var response = httpClient.GetStringAsync("https://swapi.co/api/people/1").Result;//response is a Task<string> until .Result is added to the end making it a string
            HttpResponseMessage response = httpClient.GetAsync("https://swapi.co/api/people/1").Result;//response is now an httpresponsemessage because we changed it to just GetAsync

            //Console.WriteLine(response.IsSuccessStatusCode);//404,etc, this bool is looking for good result codes (200s usually)
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                var personResponse = response.Content.ReadAsAsync<Person>().Result;
                Console.WriteLine(personResponse.Name);
                
                foreach(string vehicleURL in personResponse.Vehicles)
                {
                    Console.WriteLine(vehicleURL);
                    var vehicleResponse = httpClient.GetAsync(vehicleURL).Result;
                    var vehicleObject = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicleObject.Name);
                }
            }


            SWAPIService service = new SWAPIService();
            Person personTwo = service.GetPersonAsync("https://swapi.co/api/people/11").Result;
            if(personTwo != null)
            {
            Console.WriteLine(personTwo.Name);

                foreach(string vehicleUrl in personTwo.Vehicles)
                {
                    Vehicle vehicle = service.GetVehicleAsync(vehicleUrl).Result;
                    Vehicle genericVehicle = service.GetAsync<Vehicle>(vehicleUrl).Result;
                    Console.WriteLine(vehicle.Name);
                    Console.WriteLine(genericVehicle.Name);
                }
            }

            var skywalkers = service.GetSearchAsync<Person>("people", "skywalker").Result;
            foreach(Person person in skywalkers.Results)
            {
                Console.WriteLine(person.Name);
            }
            Console.ReadLine();
        }
    }
}
