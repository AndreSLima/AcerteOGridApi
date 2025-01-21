using AcerteOGrid.Communication.Enums;

namespace AcerteOGrid.Communication.Pilot.Response
{
    public class ResponseRegisterPilotJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public GenderType GenderType { get; set; }
    }
}
