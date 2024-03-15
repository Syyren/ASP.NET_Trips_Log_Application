using System.ComponentModel.DataAnnotations;

namespace CPRO2211_Assignment_3_Trips_Log_Application.Models
{
    public class ValidEndDate : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public ValidEndDate(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (startDateProperty == null)
            {
                return new ValidationResult($"Unknown property {_startDatePropertyName}");
            }

            var startDateValue = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);

            if (value == null)
            {
                return ValidationResult.Success;
            }

            DateTime startDate = startDateValue;
            DateTime endDate = (DateTime)value;

            //in the event that the EndDate equals or is before the StartDate, returns an error
            if (startDate == endDate) { return new ValidationResult("End Date be the same as Start Date"); }
            else if (startDate > endDate) { return new ValidationResult("End Date cannot be before Start Date"); }

            return ValidationResult.Success;
        }
    }
}