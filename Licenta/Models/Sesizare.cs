using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenta.Models
{
    public class Sesizare
    {
        [Required(ErrorMessage = "Te rog sa completezi acest camp!")]
        public String TitluSesizare { get; set; }

        public String Adresa { get; set; }
        [Required(ErrorMessage = "Te rog sa completezi acest camp!")]
        public String Descriere { get; set; }
        [Required(ErrorMessage = "Te rog sa completezi acest camp!")]
        public bool esteUrgenta { get; set; }

        public int UserID { get; set; }

        public String Message { get; set; }

        

    }
}