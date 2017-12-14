using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPCRental.Models
{
    public class userData
    {
        
        [Key]
        [Display(Name = "UserID")]
        public string ID { get; set; }


        [Required(ErrorMessage="Email must not be null")]
        [DataType(DataType.EmailAddress)]
        //[Display(Name = "UserEmail")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Password must not be null")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password must not be null")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Confirm Password must be the same with Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Fullname must not be null")]
        [Display(Name = "UserFullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone must not be null")]
        [Display(Name = "UserPhone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address must not be null")]
        [Display(Name ="UserPhone")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "UserRole")]
        [ForeignKey(nameof(Models.ROLE))]
        public string RoleID { get; set; }

        [Required]
        [Display(Name = "UserStatus")]
        public Boolean Status { get; set; }

        [Required]
        [Display(Name = "UserQuestion")]
        [ForeignKey(nameof(Models.security_questions))]
        public int SecretQuestion_ID { get; set; }


        [Required(ErrorMessage = "Answer must not be null")]
        [Display(Name = "UserAnswer")]
        public string Answer { get; set; }










    }
}