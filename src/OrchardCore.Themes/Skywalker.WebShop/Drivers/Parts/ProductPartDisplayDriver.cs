using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Skywalker.WebShop.InternalAPIs.InternalServices;
using Skywalker.WebShop.Models;
using Skywalker.WebShop.ViewModels;

namespace Skywalker.WebShop.Drivers
{
    public class ProductPartDisplayDriver: ContentPartDisplayDriver<ProductPart>
    {
        private ICategoryService _categoryService;
        public ProductPartDisplayDriver(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override IDisplayResult Display(ProductPart productPart, BuildPartDisplayContext context)
        {
            return Initialize<ProductPartViewModel>(GetDisplayShapeType(context), async m => await BuildViewModel(m, productPart))
                .Location("Detail", "Content:20")
                .Location("Summary", "Meta:5");
        }

        public override IDisplayResult Edit(ProductPart productPart, BuildPartEditorContext context)
        {
            return Initialize<ProductPartViewModel>(GetEditorShapeType(context), async m => await BuildViewModel(m, productPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(ProductPart model, IUpdateModel updater, UpdatePartEditorContext context)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Sku, t => t.CategoryId);

            return Edit(model, context);
        }

        private async Task BuildViewModel(ProductPartViewModel model, ProductPart part)
        {
            model.Sku = part.Sku;

            // Category 
            model.CategoryId = part.CategoryId;
            var categoryList = await _categoryService.GetAllCategories();

            IEnumerable<SelectListItem> categorySelectList = categoryList.Select(c => { return new SelectListItem(c.Name, c.Id); });

            model.CategoryList = categorySelectList;

            model.ContentItem = part.ContentItem;            
            model.ProductPart = part;

            //model.Attributes = _productAttributeService.GetProductAttributeFields(part.ContentItem);

            // TODO: filter out of inventory products here as well when we have inventory management
            // model.CanBeBought = ...;
        }
    }
}
