using LoremlpsumCorpWeb.ViewModels;

namespace LoremlpsumCorpWeb.Helper
{
    /// <summary>
    /// Currently this interface contains method for getting the page content and updating the page content.
    /// This has been created consider the fact that in near future we can have the same functionality for different page.
    /// This will help us re-use this interface and implement it on other pages.
    /// For example: let us consider the home page where we have Content and Heading just as about page. 
    /// So this will be help to add the functionality without creating new methods and improve code-reuseability.
    /// Additionally we can pass the file path as input so that we can read data from multiple pages and stil use one method only.
    /// </summary>
    public interface IPageHelper
    {
        /// <summary>
        /// This method will help to fetch the page heading and content.
        /// </summary>
        /// <returns>Page detais (Heading and Content)</returns>
        PageViewModel GetPageContent();

        /// <summary>
        /// Method to fetch the page details from user and update teh exsiting xml file.
        /// </summary>
        /// <param name="heading">Heading of Page</param>
        /// <param name="content">Content of Page</param>
        void UpdatePageContent(string heading, string content);
    }
}
