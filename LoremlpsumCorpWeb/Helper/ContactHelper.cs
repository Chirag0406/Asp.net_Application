using LoremlpsumCorpWeb.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace LoremlpsumCorpWeb.Helper
{
    /// <summary>
    /// Implementing the interface IContactHelper.
    /// </summary>
    public class ContactHelper : IContactHelper
    {
        /// <summary>
        /// Method to add the user entered values in contact form in to a seperate ContactDetails.json file
        /// </summary>
        /// <param name="contactViewModel">Contact veiw model parameter</param>
        public void AddContactDetails(ContactViewModel contactViewModel)
        {
            //Fetching the path where our ContactDetails.json file is stored.
            string jsonFilePath = HttpContext.Current.Server.MapPath(SiteGlobal.ContactPath);
            
            //Fetching the entire content of ContactDetails.json file
            string baseJsonContent = System.IO.File.ReadAllText(jsonFilePath);

            //Deserialize the json string into our specified object. 
            //Here we are deserializing it to a contactViewModel which contains email, name and question properties. 
            //If the json string read before is empty, we are just passing a new list.
            //This is done in order to avoid adding current user input(contactViewModel) to a null variable in next step.
            var existingContacts = JsonConvert.DeserializeObject<List<ContactViewModel>>(baseJsonContent) ?? new List<ContactViewModel>();

            //Here we are adding the current user input (contactViewModel) to the exisiting values fetched above from ContactDetails.json file. 
            existingContacts.Add(contactViewModel);

            //The final object is again serialized to JSON string format.
            //Here we are using formatting indented for better visual/layout of values in json file.
            var serializedObject = JsonConvert.SerializeObject(existingContacts, Formatting.Indented);

            //Once we have the json serilized object, we are writing it to the path specified earlier.
            System.IO.File.WriteAllText(jsonFilePath, serializedObject);
        }
    }
}