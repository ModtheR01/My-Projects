using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class User
    {
        //-----------------------------------------------------------------
        [Key]
        [DisplayName("Id")]
        public int UserId { get; set; }

        //-----------------------------------------------------------------
        [DisplayName("First Name")]
        [Required(ErrorMessage ="*The First Name Is Required ")]
        [StringLength(15,MinimumLength =3,ErrorMessage ="*First Name Must Be Between 3 & 15")]
        public string FirstName { get; set; }

        //-----------------------------------------------------------------
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "*The Last Name Is Required ")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "*Last Name Must Be Between 3 & 25")]
        public string LastName { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*The Email Is Required ")]
        [EmailAddress(ErrorMessage ="*Enter Valid Email")]
        [StringLength(50, MinimumLength =5, ErrorMessage = "*Email Must Be Between 5 & 50")]
        public string Email { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "*The Password Is Required ")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "*Password Must Be Between 8 & 30")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //-----------------------------------------------------------------
        [NotMapped]
        [Required(ErrorMessage = "The Confirm Password Is Required ")]
        [Compare("Password",ErrorMessage ="*Password & Confirm Password Not Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //-----------------------------------------------------------------






    }
}
