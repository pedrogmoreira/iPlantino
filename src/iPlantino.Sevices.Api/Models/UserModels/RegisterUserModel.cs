namespace iPlantino.Services.Api.Models.UserModels
{
    public class RegisterUserModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
