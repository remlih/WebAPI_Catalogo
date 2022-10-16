using System.Text.Json;
using Catalog.Application.Interfaces.Serialization.Options;

namespace Catalog.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}