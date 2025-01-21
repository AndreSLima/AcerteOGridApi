using AcerteOGrid.Communication.Enums;

namespace AcerteOGrid.Communication.Pilot.Request
{
    public class ResquestRegisterPilotJson
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public GenderType GenderType { get; set; }
    }
}
