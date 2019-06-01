using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CandidateApplication.Models.Candidate
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Index(IsUnique =true)]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Index(IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        [Display(Name = "Zip Code")]
        [StringLength(5, MinimumLength =5, ErrorMessage = "Invalid Zip Code.")]
        public string ZipCode { get; set; }

        public List<Qualification> Qualifications { get; set; }
    }
}