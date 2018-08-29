using LoremlpsumCorpWeb.ViewModels;

namespace LoremlpsumCorpWeb.Helper
{
    /// <summary>
    /// This interface will work as plug and play for partial view of contactform.
    /// We can just implement this method in different classes and store the details entered by user in the xml/json/database as per our need.
    /// </summary>
    public interface IContactHelper
    {
        /// <summary>
        /// Method to add the user entered values in contact form in to a seperate ContactDetails.json file
        /// </summary>
        /// <param name="contactViewModel">Contact veiw model parameter</param>
        void AddContactDetails(ContactViewModel contactViewModel);
    }
}
