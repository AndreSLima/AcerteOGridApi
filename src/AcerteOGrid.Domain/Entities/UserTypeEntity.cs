namespace AcerteOGrid.Domain.Entities
{
    public class UserTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Administrator { get; set; }
        public bool Maintenance { get; set; }
    }
}
