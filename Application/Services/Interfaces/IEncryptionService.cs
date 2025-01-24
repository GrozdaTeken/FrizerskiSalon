namespace Application.Services.Interfaces
{
    public interface IEncryptionService
    {
        string GenerateHashedPassword(string password);
    }
}
