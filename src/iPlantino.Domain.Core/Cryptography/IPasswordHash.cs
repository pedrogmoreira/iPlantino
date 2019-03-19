namespace iPlantino.Domain.Core.Cryptography
{
    public interface IPasswordHash
    {
        string CreateHash(string password);

        bool ValidatePassword(string password, string correctHash);
    }
}
