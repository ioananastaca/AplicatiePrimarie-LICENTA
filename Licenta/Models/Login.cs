using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Licenta.Models
{
    public class Login
    {
        [DisplayName("Adresa de email") ]
        [Required(ErrorMessage ="Vă rugăm să introduceți adresa de email.")]
        public string EmailAddress { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Vă rugăm să introduceți parola.")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
        public string LogOutMessage { get; set; }

    }
}