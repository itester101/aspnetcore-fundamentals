using System.ComponentModel.DataAnnotations;

namespace WebApp.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
