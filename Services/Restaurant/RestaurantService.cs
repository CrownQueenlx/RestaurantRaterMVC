using Microsoft.EntityFrameworkCore;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Restaurants;

namespace RestaurantRaterMVC.Services.Restaurants;

public class RestaurantService : IRestaurantService
{
    public RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<RestaurantListItem>> GetAllRestaurantsAsync()
     {
        List<RestaurantListItem> restaurants = await _context.Restaurants
        .Include(r => r.Ratings)
        .Select(r => new RestaurantListItem()
        {
            Id = r.Id,
            Name = r.Name,
            Score = r.AverageRating
        })
        .ToListAsync();

        return restaurants;
    }
}