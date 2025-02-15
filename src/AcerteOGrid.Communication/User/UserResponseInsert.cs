namespace AcerteOGrid.Communication.User
{
    public class UserResponseInsert: ABaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
