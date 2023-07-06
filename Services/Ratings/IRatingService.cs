using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Rating;

namespace RestaurantRaterMVC.Services.Ratings;

public interface IRatingService
{
    Task<bool> CreateRatingAsync(RatingCreate model);
    Task<List<RatingListItem>> GetRatingsAsync();
    Task<List<RatingListItem>> GetRestaurantRatingsAsync(int restaurantId);
    Task<bool> DeleteRatingAsync(int Id);
    // Task<List<RatingListItem>> GetRatingListItemAsync(int Id);
}