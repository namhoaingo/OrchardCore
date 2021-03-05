using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using Skywalker.WebShop.Drivers;
using Skywalker.WebShop.Handlers;
using Skywalker.WebShop.InternalAPIs.InternalServices;
using Skywalker.WebShop.Migrations;
using Skywalker.WebShop.Models;
using Skywalker.WebShop.Services;
using Skywalker.WebShop.Services.Implementations;

namespace Skywalker.WebShop
{
    public class Startup: StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // Product Part
            services.AddScoped<IDataMigration, ProductPartMigrations>();
            services.AddContentPart<ProductPart>()
                            .UseDisplayDriver<ProductPartDisplayDriver>()
                            .AddHandler<ProductPartContentHandler>();
            //Category
            services.AddScoped<ICategoryService, CategoryService>();


            // Price Part
            services.AddScoped<IDataMigration, PricePartMigrations>();
            services.AddContentPart<PricePart>()
                            .UseDisplayDriver<PricePartDisplayDriver>()
                            .AddHandler<PricePartContentHandler>();

            
            // Setting


        }
    }
}
