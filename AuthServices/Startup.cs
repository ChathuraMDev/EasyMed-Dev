using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AuthServices.Startup))]

namespace AuthServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll); // New code line to enable cors
            ConfigureAuth(app);
        }
    }
}
