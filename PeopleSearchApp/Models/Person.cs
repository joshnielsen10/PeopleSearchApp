using System.ComponentModel.DataAnnotations;

namespace PeopleSearchApp.Models
{
    /// <summary>
    /// Person model
    /// </summary>
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Must Provide a First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must Provide a Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must Provide an Street Address")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Must Provide a City")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must Provide a State")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Must Provide a Zip Code")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Must Provide an Age")]
        [Display(Name = "Age")]
        [Range(0, 120)]
        public int Age { get; set; }

        [Display(Name = "Interests")]
        public string Interests { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
    }
}