namespace cryptoEngine.Interfaces;

public interface IEncryptionFunctionAsync
{
    Task<string> Encrypt(string messageToEncrypt);
    Task<string> Decrypt(string messageToDencrypt);
}