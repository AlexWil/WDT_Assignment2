﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;


[assembly: OwinStartup(typeof(CineplexCustomerWebsite.Startup))]
namespace CineplexCustomerWebsite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
