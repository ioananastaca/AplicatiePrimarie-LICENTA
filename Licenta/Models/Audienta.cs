using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenta.Models
{
    public class Audienta
    {
        public int IdAudienta { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [StringLength(50)]
        public string Nume { get; set; }
      
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [DisplayName("Solicit audienta la: ")]
        public string SolicitareLa { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [RegularExpression("([0]+[7]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9])", ErrorMessage = "Numărul trebuie să înceapă cu 07**")]
        [StringLength(10, ErrorMessage = "Vă rugăm să completați acest câmp cu un număr valid în România.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Vă rugăm să completati campul de mai sus.")]
        [StringLength(255)]
        public string Motiv { get; set; }
        public int UserId { get; set; }

        public bool esteRezolvata { get; set; }

        
        public string Mentiune { get; set; }
        public string SuccesMesaj { get; set; }
    }
}