using RestaurantRaterMVC.Models.Restaurants;

namespace RestaurantRaterMVC.Services.Restaurants;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantListItem>> GetAllRestaurantsAsync();
}