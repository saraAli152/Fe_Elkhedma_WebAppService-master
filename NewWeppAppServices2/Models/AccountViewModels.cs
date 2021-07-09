using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewWeppAppServices2.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "من فضلك أدخل اسم المستخدم")]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        //[Required]
        [Display(Name = "الإيميل الإلكتروني")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل كلمة السر")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "من فضلك أدخل اسم المستخدم")]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        //[Required]
        //[DisplayName("نوع الحساب")]
        //public string UserType { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل الإيميل الإلكتروني")]

        [RegularExpression(@"^[A-Za-z0-9_\-.]+@(gmail|hotmail|yahoo)+\.(com|org|net)$",
         ErrorMessage = "هذا الإيميل غير مناسب مثال :dummy@gmail.com, dummy@hotmail.com...")]
        [EmailAddress(ErrorMessage = "هذا الإيميل غير صحيح")]
        [Display(Name = "الإيميل الإلكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل كلمة السر")]

        //    - at least 6 characters
        //- must contain at least 1 uppercase letter, 1 lowercase letter, and 1 number
        //- Can contain special characters
        [StringLength(100, ErrorMessage = " كلمة السر يجب ان تحتوي على {2} أحرف على الأقل", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
         ErrorMessage = " كلمة السر يجب ان تحتوي على 6 أحرف على الأقل / وتحتوي على الاقل حرف واحد كبير وواحد صغير ورقم واحد ")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة السر")]
        //The password and confirmation password do not match.
        [Compare("Password", ErrorMessage = "كلمة السر غير مطابقة ")]
        public string ConfirmPassword { get; set; }
    }

    public class EditProfileViewModel
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }

        

        [Required]
        [EmailAddress]
        [Display(Name = "الإيميل الإلكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " كلمة السر يجب ان تحتوي على {2} أحرف على الأقل", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة السر الحالية")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " كلمة السر يجب ان تحتوي على {2} أحرف على الأقل", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
         ErrorMessage = " كلمة السر يجب ان تحتوي على 6 أحرف على الأقل / وتحتوي على الاقل حرف واحد كبير وواحد صغير ورقم واحد ")]
        [Display(Name = "كلمة السر الجديدة")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة السر الجديدة")]
        [Compare("NewPassword", ErrorMessage = "كلمة السر غير مطابقة ")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " كلمة السر يجب ان تحتوي على {2} أحرف على الأقل", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "كلمة السر غير مطابقة ")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
