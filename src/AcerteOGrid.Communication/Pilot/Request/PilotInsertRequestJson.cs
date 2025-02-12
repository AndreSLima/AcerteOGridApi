using AcerteOGrid.Domain.Enums;

namespace AcerteOGrid.Communication.Pilot.Request
{
    public class PilotInsertRequestJson: BaseInsertRequestJson
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public GenderTypeEnum GenderType { get; set; }
    }
}
