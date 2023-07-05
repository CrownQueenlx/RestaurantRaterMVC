using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants;

public interface IRestaurantService
{
    Task<bool> CreateRestaurantAsync(RestaurantCreate model);
    Task<List<RestaurantListItem>> GetAllRestaurantsAsync();
    Task<RestaurantDetail?> GetRestaurantAsync(int id);
    Task<bool> UpdateRestaurantAsync(RestaurantEdit model);
    Task<bool> DeleteRestaurantAsync(int id);
}