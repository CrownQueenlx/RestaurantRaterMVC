using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterApi.Data;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Services.Ratings;

public class RatingService : IRatingService
{
    private readonly RestaurantDbContext _context;
    private readonly RatingListItem _rating;
    public RatingService(RestaurantDbContext context, RatingListItem rating)
    {
        _context = context;
        _rating = rating;
    }

    public async Task<bool> CreateRatingAsync(RatingCreate model)
    {
        Rating entity = new()
        {
            RestaurantId = model.RestaurantId,
            Score = model.Score
        };

        _context.Ratings.Add(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<RatingListItem>> GetRatingsAsync()
    {
        var ratings = await _context.Ratings
        .Include(r => r.Restaurant)
        .Select(r => new RatingListItem
        {
            RestaurantName = r.Restaurant.Name,
            Score = r.Score ?? 0
        })
        .ToListAsync();

        return ratings;
    }
    public async Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId)
    {
        var ratings = await _context.Ratings
        .Include(r => r.Restaurant)
        .Where(r => r.RestaurantId == restaurantId)
        .Select(r => new RatingListItem
        {
            RestaurantName = r.Restaurant.Name,
            Score = r.Score ?? 0
        })
        .ToListAsync();

        return ratings;
    }
    public async Task<bool> DeleteRatingAsync(int id)
    {
        Rating? entity = await _context.Ratings.FindAsync(id);
        if (entity is null)
            return false;
        var ratings = await _context.Ratings.Where(r => r.RestaurantId == entity.Id);
        _context.Ratings.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    // public async Task<List<RatingListItem>> GetRatingListItemAsync(RatingListItem ratingId)
    // {
    //     RatingListItem ratings = new();
    //     await _rating.tolistAsync();
    //     (ratingId.Id == ratings.Id);
    //     return ratings.ToListAsync();
    // }

}