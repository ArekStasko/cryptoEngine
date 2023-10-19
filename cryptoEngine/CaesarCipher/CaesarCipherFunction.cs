using cryptoEngine.Interfaces;

namespace cryptoEngine.CaesarCipher;

public class CaesarCipherFunction : ICaesarCipherFunction
{
    private IResources _resources;
    
    public CaesarCipherFunction(IResources resources)
    {
        _resources = resources;
    }
    
    public async Task<string> Encrypt(string messageToEncrypt)
    {
        var alphabet = _resources.GetAlphabet();
        List<string> symetricKey = _resources.GetCaesarSymetricKey();
        var result = new List<string>();

        for (int i = 0; i < messageToEncrypt.Length; i++)
        {
            var letterToEncrypt = messageToEncrypt[i];
            var indexOfLetter = alphabet.IndexOf(letterToEncrypt.ToString().ToLower());
            result.Add(symetricKey[indexOfLetter]);
        }
        
        return string.Join("", result);
    }
    
    public async Task<string> Decrypt(string messageToDencrypt)
    {
        var alphabet = _resources.GetAlphabet();
        List<string> symetricKey = _resources.GetCaesarSymetricKey();
        var result = new List<string>();

        for (int i = 0; i < messageToDencrypt.Length; i++)
        {
            var letterToEncrypt = messageToDencrypt[i];
            var indexOfLetter = symetricKey.IndexOf(letterToEncrypt.ToString().ToLower());
            result.Add(alphabet[indexOfLetter]);
        }
        
        return string.Join("", result);
    }
}