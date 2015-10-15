using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace CineplexCustomerWebsite.Hubs
{
    public class SeatAvailabilityHub : Hub
    {
        public void SignalAvailability(int seatId, Boolean available)
        {
            Clients.Others.setSeatAvailability(seatId, available);
        }
    }
}