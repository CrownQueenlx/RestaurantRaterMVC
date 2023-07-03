using RestaurantRaterApi.Data;

namespace RestaurantRaterMVC.Services.Restaurants;

public class RestaurantService : IRestaurantService
{
    public RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }
}