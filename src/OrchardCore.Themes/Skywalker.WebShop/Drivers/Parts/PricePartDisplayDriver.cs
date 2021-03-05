using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Skywalker.WebShop.Models;
using Skywalker.WebShop.MoneyDataType.Abstractions;
using Skywalker.WebShop.Services;
using Skywalker.WebShop.ViewModels;

namespace Skywalker.WebShop.Drivers
{
    public class PricePartDisplayDriver : ContentPartDisplayDriver<PricePart>
    {
        //private readonly IMoneyService _moneyService;

        //public PricePartDisplayDriver(IMoneyService moneyService)
        //{
        //    _moneyService = moneyService;
        //}

        public PricePartDisplayDriver()
        {

        }

        public override IDisplayResult Display(PricePart pricePart, BuildPartDisplayContext context)
        {
            return Initialize<PricePartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, pricePart))
                .Location("Detail", "Content:20") // Not sure what this one mean
                .Location("Summary", "Meta:5");
        }

        public override async Task<IDisplayResult> UpdateAsync(PricePart pricePart, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var updateModel = new PricePartViewModel();
            if (await updater.TryUpdateModelAsync(updateModel, Prefix, t => t.PriceValue))
            {
                pricePart.PriceValue = updateModel.PriceValue; //_moneyService.Create(updateModel.PriceValue, updateModel.PriceCurrency);
            }

            return Edit(pricePart, context);
        }

        public override IDisplayResult Edit(PricePart pricePart, BuildPartEditorContext context)
        {
            //var pricePartSettings = context.TypePartDefinition.GetSettings<PricePartSettings>();

            return Initialize<PricePartViewModel>(GetEditorShapeType(context), m =>
            {
                BuildViewModel(m, pricePart);

                // This is only required for the editor. Not the frontend display.
                //m.Currencies = GetCurrencySelectionList(pricePartSettings);
            });
        }
        private Task BuildViewModel(PricePartViewModel model, PricePart part)
        {
            model.ContentItem = part.ContentItem;

            model.Price = part.PriceValue;            
            model.PricePart = part;
            //model.PriceCurrency = part.Price.Currency.Equals(MoneyDataType.Currency.UnspecifiedCurrency) ? _moneyService.DefaultCurrency.CurrencyIsoCode : part.Price.Currency.CurrencyIsoCode;
            //model.CurrentDisplayCurrency = _moneyService.CurrentDisplayCurrency;

            return Task.CompletedTask;
        }

        //private IEnumerable<ICurrency> GetCurrencySelectionList(PricePartSettings pricePartSettings)
        //{
        //    IEnumerable<ICurrency> currencySelectionList;

        //    switch (pricePartSettings.CurrencySelectionMode)
        //    {
        //        case CurrencySelectionModeEnum.DefaultCurrency:
        //            currencySelectionList = new List<ICurrency>() { _moneyService.DefaultCurrency };
        //            break;

        //        case CurrencySelectionModeEnum.SpecificCurrency:
        //            currencySelectionList = new List<ICurrency>() { _moneyService.GetCurrency(pricePartSettings.SpecificCurrencyIsoCode) };
        //            break;

        //        default:
        //            // As a fallback show all currencies.
        //            currencySelectionList = _moneyService.Currencies;
        //            break;
        //    }

        //    return currencySelectionList;
        //}
    }
}
