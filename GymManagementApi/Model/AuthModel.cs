﻿namespace GymManagementApi.Model
{
    public class AuthModel
    {
        public string? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? Email { get; set; }
        public bool? IsAdmin { get; set; }

    }
}
