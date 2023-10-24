using System.Collections.Concurrent;

namespace cryptoEngine.Interfaces;

public interface IResources
{
    List<string> GetAlphabet();
    List<string> GetCaesarSymetricKey();
    ConcurrentDictionary<string, string> ConstructChessboard();
}