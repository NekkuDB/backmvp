namespace UserApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty; // Valor predeterminado
        public string Password { get; set; } = string.Empty; // Valor predeterminado
        public string Key { get; set; } = string.Empty; // Valor predeterminado
        public bool Is2FAEnabled { get; set; }
        public int Counter { get; set; }
    }
}
