using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ManageCredentialsViewModel
    {
        public bool HasPassword { get; set; }
        public SetPasswordViewModel SetPasswordViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public WebApplication3.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
        public bool ShowRemoveButton { get; set; }

        public UserData UserData { get; set; }
    }
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać minimum {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Hasła są różne")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać minimum {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Hasła są różne")]
        public string ConfirmPassword { get; set; }
    }

    public class EditProductViewModel
    {
        public Podzespol Podzespol { get; set; }
        public IEnumerable<podzespoly> podzespoly { get; set; }
        public bool? ConfirmSuccess { get; set; }
    }
}
