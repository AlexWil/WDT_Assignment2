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
    
    public partial class Seating
    {
        public Seating()
        {
            this.SessionBookings = new HashSet<SessionBooking>();
        }
    
        public int SeatingID { get; set; }
        public int CineplexID { get; set; }
    
        public virtual Cineplex Cineplex { get; set; }
        public virtual ICollection<SessionBooking> SessionBookings { get; set; }
    }
}