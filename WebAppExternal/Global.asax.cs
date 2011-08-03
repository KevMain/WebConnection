using System.Web;
using CCE.WebConnection.WebAppExternal.Plumbing;

namespace CCE.WebConnection.WebAppExternal
{
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// Value indicating whether this app should be in debug mode.
        /// </summary>        
        public static bool IsDebug
        {
            get { return false; }
        }

        protected void Application_Start()
        {
            Bootstrapper.Startup();
        }
    }
}