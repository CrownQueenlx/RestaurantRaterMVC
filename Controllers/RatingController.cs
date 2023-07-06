using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Rating;
using RestaurantRaterMVC.Services.Ratings;

namespace RestaurantRaterMVC.Controllers;

public class RatingController : Controller
{
    private readonly IRatingService _service;
    public RatingController(IRatingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        List<RatingListItem> model = await _service.GetRatingsAsync();
        return View(model);
    }

    [HttpGet]
    public IActionResult Create(int id)
    {
        RatingCreate model = new() { RestaurantId = id };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RatingCreate model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await _service.CreateRatingAsync(model);
        return RedirectToAction("Details", "Restaurant", new { id = model.RestaurantId });

    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        RatingListItem? Id = await _service.GetRestaurantRatingsAsync(id);
        if (Id is null)
            return RedirectToAction(nameof(Index));

        return View(Id);
    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        await _service.DeleteRatingAsync(id);
        return RedirectToAction(nameof(Index));
    }
}