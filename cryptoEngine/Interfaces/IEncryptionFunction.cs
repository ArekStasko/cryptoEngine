namespace cryptoEngine.Interfaces;

public interface IEncryptionFunction
{
    string Encrypt(string messageToEncrypt);
    string Decrypt(string messageToDencrypt);
}