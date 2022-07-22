namespace WebAPI.Models
{
    public class AccountDTO
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public AccountDTO(string username, string password, int roleId)
        {
            Username = username;
            Password = password;
            RoleId = roleId;
        }
    }
}
