
namespace UserApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public bool Is2FAEnabled { get; set; }
        public int Counter { get; set; }
    }
}
