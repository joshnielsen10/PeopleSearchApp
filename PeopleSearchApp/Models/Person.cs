using System.ComponentModel.DataAnnotations;

namespace PeopleSearchApp.Models
{
    /// <summary>
    /// Person model
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person Model
        /// </summary>
        [Key]
        public int PersonID { get; set; }

        /// <summary>
        /// First Name of Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide a First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name of Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide a Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Current Residential Street Address for Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide an Street Address")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// City of Current Residential for Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide a City")]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// State of Current Residential for Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide a State")]
        [Display(Name = "State")]
        public string State { get; set; }

        /// <summary>
        /// Zip Code of Current Residential for Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide a Zip Code")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        /// <summary>
        /// Age of Person
        /// </summary>
        [Required(ErrorMessage = "Must Provide an Age")]
        [Display(Name = "Age")]
        [Range(0, 120)]
        public int Age { get; set; }

        /// <summary>
        /// Personal Interests for Person
        /// </summary>
        [Display(Name = "Interests")]
        public string Interests { get; set; }

        /// <summary>
        /// Photo of Person
        /// </summary>
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }
}