using OrchardCore.ContentManagement;

namespace Skywalker.WebShop.Models
{
    public class ProductPart: ContentPart
    {
        
        public string Sku { get; set; }

        // Category
        public string CategoryId { get; set; }

    }
}
