using System.Text.Json.Serialization;

namespace AcerteOGrid.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserTypeEnum
    {
        Administrador = 1,
        Member = 2,
    }
}
