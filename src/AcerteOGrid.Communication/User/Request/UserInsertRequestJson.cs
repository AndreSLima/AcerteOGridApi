﻿namespace AcerteOGrid.Communication.User.Request
{
    public class UserInsertRequestJson : BaseInsertRequestJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
