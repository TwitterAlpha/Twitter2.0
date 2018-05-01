using BackUpSystem.DTO;
using BackUpSystem.Web.Models.HomeViewModels;
using System.Collections.Generic;

namespace BackUpSystem.Web.Models.SearchViewModels
{
    public class SearchResultViewModel
    {
        public IEnumerable<TwitterAccountViewModel> SearchResult { get; set; }
    }
}
