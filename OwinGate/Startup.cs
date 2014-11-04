using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(OwinGate.Startup))]
namespace OwinGate
{
    /// <summary>
    /// Starting Project
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region Statics Application, requared write permison folder

            app.Use(typeof(Logger));

            app.UseStaticFiles("/Statics");

            #endregion            
            app.Run(WebServer.Start);
        }
    }
}