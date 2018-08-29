using LoremlpsumCorpWeb.ViewModels;
using System;
using System.Web;
using System.Xml;

namespace LoremlpsumCorpWeb.Helper
{
    /// <summary>
    /// Implememting the interface IPageHelper.
    /// </summary>
    public class PageHelper: IPageHelper
    {
        private const string pageHeading = "Heading";
        private const string pageContent = "Content";
        private const string newBreakLine = "<br>";
        private const string rootTag = "//rootTag";
        
        string path;

        /// <summary>
        /// This constructor has only paramter i.e path.
        /// Here we can enter any file path and update the records or fetch the records from that file.
        /// This help to add the same functionality very easily for different pages/views.
        /// </summary>
        /// <param name="_path">file path</param>
        public PageHelper(string _path)
        {
            path = _path;
        }

        /// <summary>
        /// This method will help to fetch the page heading and content.
        /// </summary>
        /// <returns>Page detais (Heading and Content)</returns>
        public PageViewModel GetPageContent()
        {
            //Initializes a new instance of the XMLDocument class
            XmlDocument xmlDoc = new XmlDocument();

            //Loading the xml document from path specified.
            xmlDoc.Load(HttpContext.Current.Server.MapPath(path));

            var pageViewModel = new PageViewModel();

            //Here we are iterating over the xml document we loaded earlier.
            //Here rootTag is our primary tag which contains the heading and content details.
            //Once we have the rootTag, we will iterate it and pass the value fetched from heading and content page to pageViewModel.
            //Here we have replaced the <br> tag with Environment.NewLine.
            //It helps us to get the newline string in both the environment, that is for textarea and while displaying it in a view.
            foreach (XmlNode node in xmlDoc.SelectNodes(rootTag))
            {
                pageViewModel = new PageViewModel
                {
                    Heading = node[pageHeading].InnerText,
                    Content = (node[pageContent].InnerText).Replace(newBreakLine, Environment.NewLine)
                };
            }

            return pageViewModel;
        }

        /// <summary>
        /// Method to fetch the page details from user and update the exsiting xml file.
        /// </summary>
        /// <param name="heading">Heading of Page</param>
        /// <param name="content">Content of Page</param>
        public void UpdatePageContent(string heading, string content)
        {
            //Initializes a new instance of the XMLDocument class
            XmlDocument xmlDoc = new XmlDocument();

            //Loading the xml document from path specified.
            xmlDoc.Load(HttpContext.Current.Server.MapPath(path));

            //Here we are iterating over the xml document we loaded earlier.
            //Here rootTag is our primary tag which contains the heading and content details.
            //Once we have the rootTag, we will iterate it and update the value fetched from heading and content to our xml file.
            //Here we have used the replaced the Environment.NewLine with <br> tag.
            //It helps us to get the store the new line as <br> tag and then replace it again as newline for textarea and view.
            foreach (XmlNode node in xmlDoc.SelectNodes(rootTag))
            {
                node[pageHeading].InnerText = heading;
                node[pageContent].InnerText = content.Replace(Environment.NewLine, newBreakLine);
            }

            //Once we have modified our xml file as per user inputs, we save the file at the path specified earlier.
            xmlDoc.Save(HttpContext.Current.Server.MapPath(path));
        }
    }
}