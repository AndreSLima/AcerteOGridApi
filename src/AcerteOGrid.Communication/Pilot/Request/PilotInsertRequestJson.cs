namespace AcerteOGrid.Communication.Pilot.Request
{
    public class PilotInsertRequestJson
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public bool GenderType { get; set; }
    }
}
