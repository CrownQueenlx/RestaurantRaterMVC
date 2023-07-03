using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Models.Restaurants
{
    public class RestaurantListItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Display(Name = "Average Score")]
        public double? Score { get; set; }
    }
}