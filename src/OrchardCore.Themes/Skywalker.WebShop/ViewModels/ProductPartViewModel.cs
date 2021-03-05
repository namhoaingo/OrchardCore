using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.ContentManagement;
using Skywalker.WebShop.Models;

namespace Skywalker.WebShop.ViewModels
{
    public class ProductPartViewModel
    {
        // Product Sku should be required
        public string Sku { get; set; }

        // Category
        public string CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; } 

        // Bind Never that means, this will never be send back to the back end
        [BindNever]
        public bool CanBeBought { get; set; } = true;

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public ProductPart ProductPart { get; set; }

       
    }
}
