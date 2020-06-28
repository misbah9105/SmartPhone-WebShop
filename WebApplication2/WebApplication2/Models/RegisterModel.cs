using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RegisterModel
    {
        public string name { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public String email { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username can't be empty")]
        public String username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password can't be empty")]
        public String Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public String confirmpassword { get; set; }
        public string address { get; set; }
        //[RegularExpression(@"((09|03|05|07|08)+([0-9]{8}))", ErrorMessage = "Phone number invalid")]
        public int phone { get; set; }
    }
    public class LoginModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username invalid")]
        public String username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password invalid")]
        public String Password { get; set; }
    }
}