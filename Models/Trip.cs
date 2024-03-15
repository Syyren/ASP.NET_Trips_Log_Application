using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Models
{
    public class Trip
    {
        //setting the properties of the Trip class
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter a name.")]
        public string Destination { get; set; }

        //both the start and end dates have custome error handling to check that they are valid
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select a starting date.")]
        //this formatting is for displaying the date in a readable format for the user
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please select an ending date.")]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [ValidEndDate("StartDate")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Accommodation")]
        public string? Accommodation { get; set; }

        [Display(Name = "Phone")]
        //Using regular expression to check if the string is formatted correctly for a phone number.
        [RegularExpression(@"^1-\d{3}-\d{3}-\d{4}$|^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string? AccommodationPhone { get; set; }

        [Display(Name = "Email")]
        //Using regular expression to check if the string is formatted correctly for an email.
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid Email.")]
        //nullable email for the accommodations
        public string? AccommodationEmail { get; set; }

        [Display(Name = "Things to Do")]
        //nullable list of things to do at the accommodations
        public List<string>? ThingsToDo { get; set; }

        public string? Slug => Destination?.Replace(' ', '-');

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
