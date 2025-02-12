namespace AcerteOGrid.Domain.Entities
{
    public class UserTypeEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Administrator { get; set; }
        public bool Maintenance { get; set; }
        public virtual UserEntity UserEntity { get; set; } = default!;
    }
}
