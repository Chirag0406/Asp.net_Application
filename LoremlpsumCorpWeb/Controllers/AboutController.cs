using LoremlpsumCorpWeb.Helper;
using LoremlpsumCorpWeb.ViewModels;
using System.Web.Mvc;

namespace LoremlpsumCorpWeb.Controllers
{
    /// <summary>
    /// About controller class for Lorem Ipsum Corporation.
    /// </summary>
    public class AboutController : Controller
    {
        //Initializes a new instance of the PageHelper class. 
        //Here we have given about.xml path.
        private PageHelper pageHelper = new PageHelper(SiteGlobal.AboutPath);

        /// <summary>
        // Method to return About view for About Controller. 
        // GET: \About
        /// </summary>
        /// <returns>About View</returns>
        public ActionResult About()
        {
            //GetPageContent method is called to fetch data from About.xml.
            PageViewModel pageViewModel = pageHelper.GetPageContent();

            //pageViewModel is passed so that the model in \About view can get the values of Content and Heading.
            return View(pageViewModel);
        }

        /// <summary>
        /// Method to fetch data from About.xml and display it in edit view. 
        /// GET: \About\Edit
        /// </summary>
        /// <returns>Edit View</returns>
        public ActionResult Edit()
        {
            //GetPageContent method is called to fetch data from About.xml.
            var pageViewModel = pageHelper.GetPageContent();

            //pageViewModel is passed so as to fill in the textboxes with current values of Title and Content of About page fetched above.
            return View(pageViewModel);
        }

        /// <summary>
        /// Method called to update the page Heading and content fetched from user in \About\Edit view. 
        /// Additionally this method will return to \About view.
        /// </summary>
        /// <param name="Heading">Heading of about</param>
        /// <param name="Content">Content of about</param>
        /// <returns>About View</returns>
        [HttpPost]
        public ActionResult EditAbout(string heading, string content)
        {
            //UpdatePageContent method is called to update the values(heading and content) entered by user in About.xml
            pageHelper.UpdatePageContent(heading, content);

            //GetPageContent method is called to fetch data(Heading and Content) from About.xml.
            PageViewModel pageViewModel = pageHelper.GetPageContent();

            //After updating the values in About.xml, we will return to About/About view.
            //pageViewModel is passed so that the model in \About view can get the values of Content and Heading.
            return View("About", pageViewModel);
        }
    }
}