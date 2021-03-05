using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentManagement.Handlers;
using Skywalker.WebShop.Models;

namespace Skywalker.WebShop.Handlers
{
    public class ProductPartContentHandler : ContentPartHandler<ProductPart>
    {
        private readonly ILogger<ProductPartContentHandler> _logger;

        public ProductPartContentHandler(ILogger<ProductPartContentHandler> logger)
        {
            _logger = logger;
        }


        // TODO: Override remove and init function
        //public override Task ActivatedAsync(ActivatedContentContext context, ProductPart instance)
        //{
        //    _logger.LogInformation("Product Part with Sku" + instance.Sku + "is activated");
        //    return Task.CompletedTask;
        //}
        //public virtual Task ActivatingAsync(ActivatingContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task InitializingAsync(InitializingContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task InitializedAsync(InitializingContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task CreatingAsync(CreateContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task CreatedAsync(CreateContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task LoadingAsync(LoadContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task LoadedAsync(LoadContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task ImportingAsync(ImportContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task ImportedAsync(ImportContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task UpdatingAsync(UpdateContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task UpdatedAsync(UpdateContentContext context, TPart instance) => Task.CompletedTask;
        public override Task ValidatingAsync(ValidateContentContext context, ProductPart productPart)
        {
            // Check the SKu for required property
            if (string.IsNullOrWhiteSpace(productPart.Sku))
            {
                context.Fail("Sku is required");
            }
            return Task.CompletedTask;
        }
        //public virtual Task ValidatedAsync(ValidateContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task VersioningAsync(VersionContentContext context, TPart existing, TPart building) => Task.CompletedTask;
        //public virtual Task VersionedAsync(VersionContentContext context, TPart existing, TPart building) => Task.CompletedTask;
        //public virtual Task DraftSavingAsync(SaveDraftContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task DraftSavedAsync(SaveDraftContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task PublishingAsync(PublishContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task PublishedAsync(PublishContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task UnpublishingAsync(PublishContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task UnpublishedAsync(PublishContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task RemovingAsync(RemoveContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task RemovedAsync(RemoveContentContext context, TPart instance) => Task.CompletedTask;
        //public virtual Task GetContentItemAspectAsync(ContentItemAspectContext context, TPart part) => Task.CompletedTask;
        //public virtual Task CloningAsync(CloneContentContext context, TPart part) => Task.CompletedTask;
        //public virtual Task ClonedAsync(CloneContentContext context, TPart part) => Task.CompletedTask;

    }
}
