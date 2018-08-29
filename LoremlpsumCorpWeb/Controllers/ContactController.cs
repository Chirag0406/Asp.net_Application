using LoremlpsumCorpWeb.Helper;
using LoremlpsumCorpWeb.ViewModels;
using System.Web.Mvc;

namespace LoremlpsumCorpWeb.Controllers
{
    /// <summary>
    /// Contact controller class for Lorem Ipsum Corp.
    /// </summary>
    public class ContactController : Controller
    {
        //Initializes a new instance of the ContactHelper class
        ContactHelper contactHelper = new ContactHelper();

        /// <summary>
        // Method to return Contact view for Contact Controller. 
        // GET: \Contact
        /// </summary>
        /// <returns>Contact View</returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Method to update the data received from customer in customerDetails.json file.
        /// </summary>
        /// <param name="contactViewModel">contact view model</param>
        /// <returns>Json result</returns>
        [HttpPost]
        public JsonResult ContactDetails(ContactViewModel contactViewModel)
        {
            //AddContactDetails is called to write data(name, email and question) entered by user into a ContactDetails.json file 
            contactHelper.AddContactDetails(contactViewModel);

            //Return the json result that serializes the contactViewModel object passed here.
            return Json(contactViewModel);
        }
    }
}