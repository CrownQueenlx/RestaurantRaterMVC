using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterMVC.Models.Rating;

public class RatingListItem : DbContext
{
    public int Id { get; set; }

    [Display(Name = "Restaurant")]
    public string? RestaurantName { get; set; }

    [Display(Name = "Rating")]
    public double Score { get; set; }

    internal IEnumerable<object> Include(Func<object, object> value)
    {
        throw new NotImplementedException();
    }

    public static implicit operator RatingListItem(List<RatingListItem> v)
    {
        throw new NotImplementedException();
    }
}