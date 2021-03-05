using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Skywalker.WebShop.Models;
using Skywalker.WebShop.MoneyDataType;
using Skywalker.WebShop.MoneyDataType.Abstractions;

namespace Skywalker.WebShop.ViewModels
{
    public class PricePartViewModel
    {
        // This is the model, we will convert it to the the Amount- Price later
        public decimal PriceValue { get; set; }

        [BindNever]
        public decimal Price { get; set; }

        // These are the content parts
        [BindNever]
        public ContentItem ContentItem { get; set; }
        [BindNever]
        public PricePart PricePart { get; set; }
        
    }
}
