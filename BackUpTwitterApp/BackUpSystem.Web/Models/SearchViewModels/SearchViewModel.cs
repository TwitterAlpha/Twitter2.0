using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Web.Models.SearchViewModels
{
    public class SearchViewModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        [DataType(DataType.Text)]
        public string UserInput { get; set; }
    }
}
