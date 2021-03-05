using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement.Handlers;
using Skywalker.WebShop.Models;

namespace Skywalker.WebShop.Handlers
{
    public class PricePartContentHandler: ContentPartHandler<PricePart>
    {
        private readonly ILogger<PricePartContentHandler> _logger;

        public PricePartContentHandler(ILogger<PricePartContentHandler> logger)
        {
            _logger = logger;
        }

        //public override Task ActivatedAsync(ActivatedContentContext context, PricePart instance)
        //{
        //    _logger.LogInformation("Price Part with price" + instance.Price + "is activated");
        //    return Task.CompletedTask;
        //}
    }
}
