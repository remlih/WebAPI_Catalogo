
using Catalog.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace Catalog.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}