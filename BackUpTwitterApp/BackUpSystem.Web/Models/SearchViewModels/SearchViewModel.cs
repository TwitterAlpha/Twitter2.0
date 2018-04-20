using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Models.SearchViewModels
{
    public class SearchViewModel
    {
        [Required]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string UserInput { get; set; }
    }
}
