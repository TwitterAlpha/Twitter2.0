using BackUpSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Models.SearchViewModels
{
    public class SearchResultViewModel
    {
        public ICollection<TwitterAccountApiDto> SearchResult { get; set; }
    }
}
