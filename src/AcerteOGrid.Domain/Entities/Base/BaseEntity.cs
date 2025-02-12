namespace AcerteOGrid.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int UserInclusion { get; set; }
        public DateTime DateInclusion { get; set; }
        public int? UserChange { get; set; }
        public DateTime? DateChange { get; set; }
    }
}
