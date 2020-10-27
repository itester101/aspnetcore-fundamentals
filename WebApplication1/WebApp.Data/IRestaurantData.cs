using System.Collections.Generic;
using WebApp.Core;
using System.Linq;

namespace WebApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestuarantsByName(string name = null);
        Restaurant GetById(int id);
    }

    public class InMemoryRestuaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestuaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Tutti Santi", Location = "Grzybowska", Cuisine = CuisineType.Italian },
                new Restaurant() { Id = 2, Name = "San Thai", Location = "Próżna", Cuisine = CuisineType.Indian},
                new Restaurant() { Id = 3, Name = "Hektor", Location = "Świętokrzyska", Cuisine = CuisineType.Polish}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestuarantsByName(string name = null)
        {
            return GetAll().Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name));
        }
    }
}

