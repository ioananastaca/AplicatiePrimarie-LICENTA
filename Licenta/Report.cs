//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Licenta
{
    using System;
    using System.Collections.Generic;
    
    public partial class Report
    {
        public int Id { get; set; }
        public string TitlulSesizarii { get; set; }
        public string Adresa { get; set; }
        public string Descriere { get; set; }
        public bool EsteUrgenta { get; set; }
        public int UserId { get; set; }
        public bool IsResolved { get; set; }
    
        public virtual User User { get; set; }
    }
}