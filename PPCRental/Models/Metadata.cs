using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPCRental.Models
{
    public class USERMetadata
    {
        [Key]
        [Display(Name = "UserID")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Email must not be null")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password must not be null")]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{4,20}$", ErrorMessage= "Minimum four characters and maximun twenty characters, at least one uppercase letter, one lowercase letter and one number.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password must not be null")]
        [Compare("Password", ErrorMessage = "Password Mismatched. Re-enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Fullname must not be null")]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone must not be null")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address must not be null")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Security Question")]
        [ForeignKey(nameof(Models.security_questions))]
        public int SecretQuestion_ID { get; set; }

        [Required(ErrorMessage = "Answer must not be null")]
        [Display(Name = "Answer")]
        public string Answer { get; set; }

    }

    public class ForgotPasswordViewModel{

        [Required(ErrorMessage = "Email must not be null")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Security Question")]
        [ForeignKey(nameof(Models.security_questions))]
        public int SecretQuestion_ID { get; set; }

        [Required(ErrorMessage = "Answer must not be null")]
        [Display(Name = "Answer")]
        public string Answer { get; set; }
    }
}