using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoremlpsumCorpWeb.ViewModels
{
    public class ContactViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Question { get; set; }
    }
}