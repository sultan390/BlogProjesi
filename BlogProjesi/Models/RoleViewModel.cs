using System.ComponentModel.DataAnnotations;

namespace BlogProjesi.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol adı Giriniz")]
        public required string Name { get; set; }
    }
}
