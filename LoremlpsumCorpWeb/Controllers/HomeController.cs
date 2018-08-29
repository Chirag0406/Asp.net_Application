using System.Web.Mvc;

namespace LoremlpsumCorpWeb.Controllers
{
    /// <summary>
    /// Home controller class for Lorem Ipsum Corporation.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Method to return Index view for Home controller.
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}