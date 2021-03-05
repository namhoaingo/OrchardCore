using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Skywalker.WebShop.MoneyDataType;

namespace Skywalker.WebShop.ViewModels
{
    public class CommerceSettingsViewModel
    {
        public string DefaultCurrency { get; set; }
        public string CurrentDisplayCurrency { get; set; }

        public IEnumerable<SelectListItem> Currencies { get; set; }

        [BindNever]
        public Currency Currency { get; set; }
    }
}
