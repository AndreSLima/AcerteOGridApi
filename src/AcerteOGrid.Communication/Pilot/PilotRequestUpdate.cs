using AcerteOGrid.Domain.Enums;
using System.Text.Json.Serialization;

namespace AcerteOGrid.Communication.Pilot
{
    public class PilotRequestUpdate : ABaseRequestUpdate
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public GenderTypeEnum GenderType { get; set; }
    }
}
