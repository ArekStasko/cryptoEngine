using System.Text;
using cryptoEngine.Interfaces;

namespace cryptoEngine.PolybiusChessboard;

public class PolybiusChessboardFunctionAsync : IPolybiusChessboardFunctionAsync
{
    private readonly IResources _resources;
    
    public PolybiusChessboardFunctionAsync(IResources resources)
    {
        _resources = resources;
    }
    public string Encrypt(string messageToEncrypt)
    {
        var chessboard = _resources.ConstructChessboard();
        var result = new StringBuilder();
        foreach (var character in messageToEncrypt)
        {
            string characterToEncode = character.ToString().ToLower();
            var encodedCharacter = chessboard.FirstOrDefault(c => c.Value == characterToEncode).Key;
            if (encodedCharacter is null) throw new Exception("There is no key for provided character");
            result.Append($"{encodedCharacter} ");
        }

        return result.ToString();
    }

    public string Decrypt(string messageToDecrypt)
    {
        var chessboard = _resources.ConstructChessboard();
        var charactersToDecrypt = messageToDecrypt.Trim().Split(' ');
        var result = new StringBuilder();
        foreach (var character in charactersToDecrypt)
        {
            string characterToDecode = character.ToLower();
            string decodedCharacter = chessboard.GetValueOrDefault(characterToDecode);
            if (decodedCharacter is null) throw new Exception("There is no value for provided character");
            result.Append(decodedCharacter);
        }

        return result.ToString();
    }
}