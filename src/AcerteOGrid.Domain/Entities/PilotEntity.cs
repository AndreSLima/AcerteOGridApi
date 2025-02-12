namespace AcerteOGrid.Domain.Entities
{
    public class PilotEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public bool? GenderType { get; set; }
    }
}
