//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieSession
    {
        public int SessionID { get; set; }
        public int CineplexID { get; set; }
        public int MovieID { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual Cineplex Cineplex { get; set; }
        public virtual Movie Movie { get; set; }
    }
}