using OrchardCore.ContentManagement;
using Skywalker.WebShop.MoneyDataType;

namespace Skywalker.WebShop.Models
{
    public class PricePart: ContentPart
    {
        //public Amount Price { get; set; } = new Amount(0, Currency.UnspecifiedCurrency);
        public decimal PriceValue { get; set; }
    }
}
