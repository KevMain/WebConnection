using System.Web.Mvc;

namespace CCE.WebConnection.WebAppExternal.Controllers
{
    /// <summary>
    /// Controller for home actions
    /// </summary>
    [HandleError]
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
