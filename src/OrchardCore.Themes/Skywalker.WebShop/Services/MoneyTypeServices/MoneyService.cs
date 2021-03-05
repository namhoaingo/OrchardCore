using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Skywalker.WebShop.Models.Settings;
using Skywalker.WebShop.MoneyDataType;
using Skywalker.WebShop.MoneyDataType.Abstractions;

namespace Skywalker.WebShop.Services.Implementations
{
    public class MoneyService : IMoneyService
    {
        private readonly IEnumerable<ICurrencyProvider> _currencyProviders;
        private readonly CommerceSettings _options;
        private readonly ICurrencySelector _currencySelector;

        public MoneyService(
            IEnumerable<ICurrencyProvider> currencyProviders,
            IOptions<CommerceSettings> options,
            ICurrencySelector currencySelector)
        {
            _currencyProviders = currencyProviders ?? Array.Empty<ICurrencyProvider>();
            _options = options?.Value;
            _currencySelector = currencySelector;
        }

        public IEnumerable<ICurrency> Currencies
            => _currencyProviders
                .SelectMany(p => p.Currencies)
                .OrderBy(c => c.CurrencyIsoCode);

        public ICurrency DefaultCurrency
        {
            get
            {
                var defaultIsoCode = _options?.DefaultCurrency;
                return string.IsNullOrEmpty(defaultIsoCode)
                    ? Currency.USDollar
                    : GetCurrency(_options.DefaultCurrency)
                    ?? Currency.USDollar;
            }
        }

        public ICurrency CurrentDisplayCurrency
        {
            get
            {
                return _currencySelector.CurrentDisplayCurrency ?? DefaultCurrency;
            }
        }

        public Amount Create(decimal value, string currencyIsoCode)
            => new Amount(value, GetCurrency(currencyIsoCode));

        public Amount EnsureCurrency(Amount amount)
            => new Amount(amount.Value, GetCurrency(amount.Currency.CurrencyIsoCode));

        public ICurrency GetCurrency(string currencyIsoCode)
            => Currency.FromISOCode(currencyIsoCode, _currencyProviders);
    }
}
