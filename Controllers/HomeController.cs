using CPRO2211_Assignment_3_Trips_Log_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Controllers
{
    public class HomeController : Controller
    {
        //declaring the trip context class as an object that is a property of the controller
        private TripContext context { get; set; }

        //setting the constructor that takes in the trip as a parameter and applies it to the property

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TripContext ctx)
        {
            context = ctx;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ensures the loading of the categories
            var trips = context.Trips.OrderBy(
                trip => trip.StartDate).ToList();
            return View(trips); //returns a view that has a table with a list of the contacts in the database
        }

        //action method that gets the details of a specified trip via its id
        [HttpGet]
        public IActionResult Details(int id)
        {
            //grabs the matching trip by id
            var trip = context.Trips.FirstOrDefault(t => t.Id == id);
            return View(trip); //returns a view that shows the details of that specific id
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
