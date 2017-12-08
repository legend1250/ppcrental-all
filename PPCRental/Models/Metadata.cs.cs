using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPCRental.Models
{
    public class UserMetadata
    {
        
        [Key]
        [Display(Name = "UserID")]
        public string ID;


        [Required]
        [EmailAddress]
        [Display(Name = "UserEmail")]
        public string Email;

        [Required]
        [Display(Name = "UserPassword")]
        public string Password;

        [Required]
        [Display(Name = "UserFullName")]
        public string FullName;

        [Required]
        [Display(Name = "UserPhone")]
        public string Phone;
        [Required]
        public string Address;

        [Required]
        [Display(Name = "UserRole")]
        [ForeignKey(nameof(Models.ROLE))]

        public string RoleID;

        [Required]
        [Display(Name = "UserStatus")]
        public string Status;

        [Required]
        [Display(Name = "UserQuestion")]
        public string SecretQuestion_ID;


        [Required]
        [Display(Name = "UserAnswer")]
        public string Answer;
        









    }
}