namespace AcerteOGrid.Communication.User
{
    public class UserRequestInsert : ABaseRequestInsert
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
