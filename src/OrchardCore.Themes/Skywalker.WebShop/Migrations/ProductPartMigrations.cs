using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Skywalker.WebShop.Migrations
{
    public class ProductPartMigrations: DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public ProductPartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            // Now you can configure ProdussssctPart. For example you can add content fields (as mentioned earlier) here.
            _contentDefinitionManager.AlterPartDefinition("ProductPart", builder => builder
                .Attachable()
                .WithDisplayName("Product Part")
                .WithDescription("Makes a content item into a product."));

            return 1;
        }
    }
}
