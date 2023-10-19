namespace cryptoEngine.Interfaces;

public interface IEncryptionFunction
{
    Task<string> Encrypt(string messageToEncrypt);
    Task<string> Decrypt(string messageToDencrypt);
}