using System.ComponentModel.DataAnnotations;

namespace BlogProjesi.Models
{
    public class UserSignİnViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string password { get; set; }

        // public string mail { get; set; }
    }
}
