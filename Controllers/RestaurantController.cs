using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Restaurant;
using RestaurantRaterMVC.Services.Restaurants;

namespace RestaurantRaterMVC.Controllers;

public class RestaurantController : Controller
{
    private IRestaurantService _service;
    public RestaurantController(IRestaurantService service)
    {
        _service = service;
    }
    public async Task<IActionResult> Index()
    {
        List<RestaurantListItem> restaurants = (List<RestaurantListItem>)await _service.GetAllRestaurantsAsync();
        return View(restaurants);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(RestaurantCreate model)
    {
        if (!ModelState.IsValid)
        return View(model);
        await _service.CreateRestaurantAsync(model);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    { //store the detail model and call service method
        RestaurantDetail? model = await _service.GetRestaurantAsync(id);
        if (model is null)
        return NotFound();

        return View(model);
    }
}