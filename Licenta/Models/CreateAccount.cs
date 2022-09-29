using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licenta.Models
{
    public class CreateAccount
    {
        [DisplayName("Adresa de email")]
        [Required(ErrorMessage = "Te rog sa introduci adresa de e-mail")]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Te rog sa introduci parola")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Parola trebuie sa contina mai mult de 3 caractere")]
        public string Password { get; set; }
        public bool AccountCreated { get; set; }
    }
}