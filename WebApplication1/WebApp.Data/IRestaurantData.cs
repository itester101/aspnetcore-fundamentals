using System.Collections.Generic;
using WebApp.Core;
using System.Linq;

namespace WebApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestuaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestuaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Tutti Santi", Location = "Grzybowska", Cuisine = CuisineType.Italian },
                new Restaurant() { Id = 1, Name = "San Thai", Location = "Próżna", Cuisine = CuisineType.Indian},
                new Restaurant() { Id = 1, Name = "Hektor", Location = "Świętokrzyska", Cuisine = CuisineType.Polish}

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}

