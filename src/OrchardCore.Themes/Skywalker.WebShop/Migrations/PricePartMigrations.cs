using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace Skywalker.WebShop.Migrations
{
    public class PricePartMigrations: DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PricePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            // Now you can configure PricePart. For example you can add content fields (as mentioned earlier) here.
            _contentDefinitionManager.AlterPartDefinition("PricePart", builder => builder
                .Attachable()
                // Enable attach multple price into a single item
                .Reusable()
                .WithDisplayName("Price Part")
                .WithDescription("Makes a content item into a price."));

            return 1;
        }
    }
}
