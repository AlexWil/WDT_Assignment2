//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CineplexCustomerWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieSession
    {
        public MovieSession()
        {
            this.Seating = new HashSet<Seating>();
            this.SessionBooking = new HashSet<SessionBooking>();
        }
    
        public int SessionID { get; set; }
        public int CineplexID { get; set; }
        public int MovieID { get; set; }
        public System.DateTime SessionDateTime { get; set; }
    
        public virtual CineplexMovie CineplexMovie { get; set; }
        public virtual ICollection<Seating> Seating { get; set; }
        public virtual ICollection<SessionBooking> SessionBooking { get; set; }
    }
}
