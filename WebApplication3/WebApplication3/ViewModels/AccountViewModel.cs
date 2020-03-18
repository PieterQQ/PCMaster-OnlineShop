using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class LoginViewModel
    {
       
            [Required(ErrorMessage = "Musisz wprowadzić e-mail")]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required(ErrorMessage = "Musisz wprowadzić hasło")]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [Display(Name = "Zapamiętaj mnie")]
            public bool RememberMe { get; set; }
        
    }
}