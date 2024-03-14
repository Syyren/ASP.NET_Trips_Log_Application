using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Models
{
    public class Trip
    {
        //setting the properties of the Trip class
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter a name.")]
        public string Destination { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select a starting date.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please select an ending date.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Accommodation")]
        public string? Accommodation { get; set; }

        [Display(Name = "Phone")]
        //Using regular expression to check if the string is formatted correctly for a phone number.
        [Required(ErrorMessage = "Please enter a phone number.")]
        [RegularExpression(@"^1-\d{3}-\d{3}-\d{4}$|^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string? AccommodationPhone { get; set; }

        [Display(Name = "Email")]
        //Using regular expression to check if the string is formatted correctly for an email.
        [Required(ErrorMessage = "Please enter an Email.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid Email.")]
        //nullable email for the accommodations
        public string? AccommodationEmail { get; set; }

        [Display(Name = "Things to Do")]
        //nullable list of things to do at the accommodations
        public List<string>? ThingsToDo { get; set; }

        public string Slug => Destination?.Replace(' ', '-');

        //defining an empty constructor
        public Trip()
        {
            Id = 0;
            Destination = "Invalid";
            StartDate = System.DateTime.MinValue;
            EndDate = System.DateTime.MaxValue;
        }

        //constructor that takes in all values to construct a proper object
        public Trip(int id, string destination, DateTime startDate, DateTime endDate, string? accommodation, string? accommodationPhone, string? accommodationEmail, List<string>? thingsToDo)
        {
            Id = id;
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            Accommodation = accommodation;
            AccommodationPhone = accommodationPhone;
            AccommodationEmail = accommodationEmail;
            ThingsToDo = thingsToDo;
        }
    }
}
