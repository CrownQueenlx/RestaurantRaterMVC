using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterApi.Data;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options) { }

    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Rating> Ratings { get; set; } = null!;
}