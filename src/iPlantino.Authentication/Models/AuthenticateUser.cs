namespace iPlantino.Authentication.Models
{
    public class AuthenticateUser
    {
        public AuthenticateUser(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}