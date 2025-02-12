using System.Text.Json.Serialization;

namespace AcerteOGrid.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GenderTypeEnum
    {
        Female = 0,
        Male = 1,
    }
}
