using SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI
{
    class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Person> GetPersonAsync(string url)//when we use async keyword, we have to return a task<>, but in the code we can just return the object
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Person person = await response.Content.ReadAsAsync<Person>();
                return person;
            }
            return null;
        }

        public async Task<Vehicle> GetVehicleAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Vehicle>();
            }
            return null;
        }

        public async Task<T> GetAsync<T>(string url)//this is generic typing - T stands in for whatever type you will need it to be 
            //(like List class) - doesn't have to be T, it can be any string      
            //T is just saying - "i don't know what type i will be returning yet"
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;//default is catch-all response for reference types and value types
        }

        public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.co/api/{category}/?search={query}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }
            return default;
        }

        public async Task<SearchResult<Person>> GetPersonSearchAsyn(string query)
        {
            return await GetSearchAsync<Person>("people", query);
        }
    }
}
