using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCore.Hashids
{
    public class ConfigureJsonOptions : IConfigureOptions<JsonOptions>
    {
        public void Configure(JsonOptions options)
        {
            options.JsonSerializerOptions.Converters.Add(new HashidsJsonConverter());
        }
    }
}
