using Microsoft.EntityFrameworkCore;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurants;

public class RestaurantService : IRestaurantService
{
    public RestaurantDbContext _context;
    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }
    public async Task<List<RestaurantListItem>> GetAllRestaurantsAsync()
    {
        List<RestaurantListItem> restaurants = await _context.Restaurants
        .Include(r => r.Ratings)
        .Select(r => new RestaurantListItem()
        {
            Id = r.Id,
            Name = r.Name,
            Score = r.AverageRating ?? 0
        })
        .ToListAsync(); //make into c# list

        return restaurants;
    }
    public async Task<bool> CreateRestaurantAsync(RestaurantCreate model)
    {
        Restaurant entity = new()
        {
            Name = model.Name,
            Location = model.Location
        };
        _context.Restaurants.Add(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<RestaurantDetail?> GetRestaurantAsync(int id)
    {
        Restaurant? restaurant = await _context.Restaurants
        .Include(r => r.Ratings)
        .FirstOrDefaultAsync(r => r.Id == id);

        return restaurant is null ? null : new()
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Location = restaurant.Location,
            Score = restaurant.AverageRating ?? 0 
        };
    }
}