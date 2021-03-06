using System.Collections.Generic;
using Skywalker.WebShop.MoneyDataType.Abstractions;
using Skywalker.WebShop.Services;

namespace Skywalker.WebShop.MoneyDataType
{
    /// <summary>
    /// A simple currency provider that uses a static list of the most common predefined currencies
    /// </summary>
    public class CurrencyProvider : ICurrencyProvider
    {
        public CurrencyProvider()
        {
            KnownCurrencyTable.EnsureCurrencyTable();
        }

        public IEnumerable<ICurrency> Currencies
            => KnownCurrencyTable.CurrencyTable.Values;

        public ICurrency GetCurrency(string isoSymbol)
            => KnownCurrencyTable.CurrencyTable.TryGetValue(isoSymbol, out var value) ? value : null;

        public bool IsKnownCurrency(string isoCode) 
            => KnownCurrencyTable.CurrencyTable.ContainsKey(isoCode);
    }
}
