using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Environment.Shell;
using OrchardCore.Settings;
using Skywalker.WebShop.Models.Settings;
using Skywalker.WebShop.Services;
using Microsoft.AspNetCore.Authorization;
using Skywalker.WebShop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Skywalker.WebShop.Drivers.Settings
{
    //Control the display for commercial settings
    public class CommerceSettingsDisplayDriver: SectionDisplayDriver<ISite, CommerceSettings>
    {

        public const string GroupId = "commerce";
        private readonly IShellHost _orchardHost;
        private readonly ShellSettings _currentShellSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMoneyService _moneyService;
        private readonly IStringLocalizer S;

        public CommerceSettingsDisplayDriver(IShellHost orchardHost, ShellSettings currentShellSettings, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService, IMoneyService moneyService, IStringLocalizer s)
        {
            _orchardHost = orchardHost;
            _currentShellSettings = currentShellSettings;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
            _moneyService = moneyService;
            S = s;
        }

        public override async Task<IDisplayResult> EditAsync(CommerceSettings commerceSettings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, PermissionProvider.PermissionProvider.ManageCommerceSettings))
            {
                return null;
            }

            var shapes = new List<IDisplayResult>
            {
                Initialize<CommerceSettingsViewModel>("CommerceSettings_Edit", model =>
                {
                    model.DefaultCurrency = commerceSettings.DefaultCurrency ?? _moneyService.DefaultCurrency.CurrencyIsoCode;
                    model.CurrentDisplayCurrency = commerceSettings.CurrentDisplayCurrency ?? _moneyService.DefaultCurrency.CurrencyIsoCode;
                    model.Currencies = _moneyService.Currencies
                        .OrderBy(c => c.CurrencyIsoCode)
                        .Select(c => new SelectListItem(
                            c.CurrencyIsoCode,
                            $"{c.CurrencyIsoCode} {c.Symbol} - {S[c.EnglishName]}"));
                }).Location("Content:5").OnGroup(GroupId)
            };

            return Combine(shapes);

        }
        public override async Task<IDisplayResult> UpdateAsync(CommerceSettings section, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, PermissionProvider.PermissionProvider.ManageCommerceSettings))
            {
                return null;
            }

            if (context.GroupId == GroupId)
            {
                var model = new CommerceSettingsViewModel();

                if (await context.Updater.TryUpdateModelAsync(model, Prefix))
                {
                    section.DefaultCurrency = model.DefaultCurrency;
                    section.CurrentDisplayCurrency = model.CurrentDisplayCurrency;
                }

                // Reload the tenant to apply the settings
                await _orchardHost.ReloadShellContextAsync(_currentShellSettings);
            }

            return await EditAsync(section, context);
        }


    }
}
