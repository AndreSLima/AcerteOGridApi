using AcerteOGrid.Domain.Enums;

namespace AcerteOGrid.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid Identifier { get; set; }
        public string Role { get; set; } = RolesEnum.MEMBER;
    }
}
