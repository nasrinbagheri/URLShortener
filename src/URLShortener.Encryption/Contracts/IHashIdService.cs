namespace URLShortener.Encryption.Contracts
{
    public interface IHashIdService
    {
        string Encrypt(long id);

        long Decrypt(string encryptedId);
    }
}
