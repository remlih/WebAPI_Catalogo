using System.Linq;
using Catalog.Shared.Constants.Localization;
using Catalog.Shared.Settings;

namespace Catalog.WebAPIServer.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "es-ES";

        //TODO - add server preferences
    }
}