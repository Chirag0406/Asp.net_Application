using System.Configuration;

namespace LoremlpsumCorpWeb.Helper
{
    /// <summary>
    /// Class for all the static properties that must be initialized at run time.
    /// </summary>
    public static class SiteGlobal
    {
        /// <summary>
        /// Path where about.xml is stored.
        /// </summary>
        static public string AboutPath { get; set; }

        /// <summary>
        /// Path where contactDetail.json is stored.
        /// </summary>
        static public string ContactPath { get; set; }

        // Static constructor to initialize all the static properties.
        static SiteGlobal()
        {
            AboutPath = ConfigurationManager.AppSettings["aboutPath"];
            ContactPath = ConfigurationManager.AppSettings["contactPath"];
        }
    }
}