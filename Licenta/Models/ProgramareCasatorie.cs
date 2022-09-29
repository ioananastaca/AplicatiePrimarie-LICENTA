using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Licenta.Models
{
    public class ProgramareCasatorie
    {
        public byte Id { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        public string Hour { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        public string  HusbandName { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [RegularExpression("([0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9])", ErrorMessage = "Acest camp trebuie compus doar din cifre")]
        [StringLength(13,ErrorMessage ="Formatul CNP-ului este gresit.")]
        public string  HusbandCNP { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        public string  WifeName { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [RegularExpression("([0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9])", ErrorMessage = "Acest camp trebuie compus doar din cifre")]
        [StringLength(13, ErrorMessage = "Formatul CNP-ului este gresit.")]
        public string  WifeCNP { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]

        public string  EmailAdress { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]

        [RegularExpression("([0]+[7]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9])", ErrorMessage = "Acest camp trebuie compus doar din cifre")]
        [StringLength(10, ErrorMessage = "Vă rugăm să completați acest câmp cu un număr valid în România.")]
        public string  PhoneNumber { get; set; }
        public int UserID { get; set; }
        public string  SuccessMessage { get; set; }
        public List<KeyValuePair<string, string>> BookedMarriages { get; set; }
    }
}