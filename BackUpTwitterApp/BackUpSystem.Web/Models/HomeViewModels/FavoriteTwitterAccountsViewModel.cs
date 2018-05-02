using System.Collections.Generic;

namespace BackUpSystem.Web.Models.HomeViewModels
{
    public class FavoriteTwitterAccountsViewModel
    {
        public IEnumerable<TwitterAccountViewModel> TwitterAccounts { get; set; }
    }
}
