using System.Collections.Generic;
using WebApp.Core;
using System.Linq;

namespace WebApp.Data
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
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

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestuarantsByName(string name = null)
        {
            return GetAll().Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name));
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}

