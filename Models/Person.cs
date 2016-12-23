using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimpleASPApp.Models
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please Enter your Name in 3 to 10 character")]
        [StringLength(10, MinimumLength = 3)]
        [DisplayName("First Name")]
       // [Column(TypeName = "varchar")]
        public String FirstName { get; set; }



        [Required(ErrorMessage = "Please Enter your Last name in 3 to 20 chacater ")]
        [StringLength(20,MinimumLength = 3)]
        [DisplayName( "Last Name")]
        public string LastName { get; set; }

      
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
                         ErrorMessage = "Email doesn't look like a valid email address.")]
        [StringLength(100, ErrorMessage = "The Address should be in 100 character  ")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You should enter your Birthdate ")]
        [DisplayName("Birth Date")]
        public DateTime DateOfBirth { get; set; }
    }
}