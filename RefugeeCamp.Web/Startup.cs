﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RefugeeCamp.Web.Startup))]
namespace RefugeeCamp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
