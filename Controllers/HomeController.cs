using CPRO2211_Assignment_3_Trips_Log_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Controllers
{
    public class HomeController : Controller
    {
        //declaring the trip context class as an object that is a property of the controller
        private TripContext context { get; set; }

        private Packer packer = new Packer();

        //setting the constructor that takes in the trip as a parameter and applies it to the property

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TripContext ctx)
        {
            context = ctx;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            TempData.Clear(); //whenever the user is directed to the index, temp data is cleared
            //ensures the loading of the trips in order of next start date
            var trips = context.Trips.OrderBy(
                trip => trip.StartDate).ToList();
            return View(trips); //returns a view that has a table with a list of the contacts in the database
        }

        //action method that utilizes TempData to go through multiple pages and create a new trip
        [HttpGet]
        [Route("/add/page-1")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/add/page-1")]
        public IActionResult Add(Trip tripTempData)
        {
            if (!ModelState.IsValid)
            {
                return View(tripTempData);
            }
            if (tripTempData.Accommodation is null)
            {
                tripTempData.Accommodation = "No Accommodations";
                tripTempData.AccommodationPhone = "";
                tripTempData.AccommodationEmail = "";
                TempData["Trip"] = packer.Pack(tripTempData);
                return RedirectToAction("Add3");
            }
            TempData["Trip"] = packer.Pack(tripTempData);
            return RedirectToAction("Add2");
        }

        [HttpGet]
        [Route("/add/page-2")]
        public IActionResult Add2()
        {
            string tripJson = TempData["Trip"] as string;
            Trip trip = packer.Unpack(tripJson);

            Console.WriteLine($"page get 2 json: {tripJson}");

            if (trip is null)
            {
                return RedirectToAction("Add"); //redirects to the first page in the event of no data
            }
            TempData["Trip"] = packer.Pack(trip);
            return View(); //shows page 2
        }

        [HttpPost]
        [Route("/add/page-2")]
        public IActionResult Add2(Trip tripTempData)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Property: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(tripTempData);
            }
            //update temp trip data
            string tripJson = TempData["Trip"] as string;
            Trip trip = packer.Unpack(tripJson);

            Console.WriteLine($"page post 2 json: {tripJson}");

            trip.AccommodationPhone = tripTempData.AccommodationPhone;
            trip.AccommodationEmail = tripTempData.AccommodationEmail;
            TempData["Trip"] = packer.Pack(trip);

            return RedirectToAction("Add3"); //redirects to page 3
        }

        [HttpGet]
        [Route("add/page-3")]
        public IActionResult Add3()
        {
            string tripJson = TempData["Trip"] as string;
            Trip trip = packer.Unpack(tripJson);

            Console.WriteLine($"page 3 get json: {tripJson}");

            if (trip == null)
            {
                return RedirectToAction("Add");
            }
            TempData["Trip"] = packer.Pack(trip);

            return View(trip);
        }

        [HttpPost]
        [Route("add/page-3")]
        public IActionResult Add3(Trip tripTempData)
        {
            if (!ModelState.IsValid)
            {
                return View(tripTempData);
            }
            //update trip data with things to do
            string tripJson = TempData["Trip"] as string;
            Trip trip = packer.Unpack(tripJson);

            Console.WriteLine($"page 3 post json: {tripJson}");

            trip.ThingsToDo = tripTempData.ThingsToDo;
            TempData["Trip"] = packer.Pack(trip);

            context.Trips.Add(trip);
            context.SaveChanges();

            //redirect to the index with a success message in the temp data
            TempData["SuccessMessage"] = "Success!";
            return RedirectToAction("Index", "Home");
        }

        //action method that gets the details of a specified trip via its id
        [HttpGet]
        public IActionResult Details(int id)
        {
            //grabs the matching trip by id
            var trip = context.Trips.FirstOrDefault(t => t.Id == id);
            return View(trip); //returns a view that shows the details of that specific id
        }

        //action method that gets the necessary information to delete a trip via id
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var trip = context.Trips.Find(id);
            return View(trip); //returns a view with the information for the trip being deleted
        }

        //action method that posts a deletion of a given trip
        [HttpPost]
        public IActionResult Delete(Trip trip)
        {
            context.Trips.Remove(trip);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Success!";
            return RedirectToAction("Index"); //returns the index view after deletion is successful
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
