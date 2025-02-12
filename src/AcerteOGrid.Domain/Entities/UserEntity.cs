using System.ComponentModel.DataAnnotations.Schema;

namespace AcerteOGrid.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("TipoUsuario")]
        public int UserTypeEntityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid Identifier { get; set; }
        public virtual UserTypeEntity UserTypeEntity { get; set; } = default!;
    }
}
