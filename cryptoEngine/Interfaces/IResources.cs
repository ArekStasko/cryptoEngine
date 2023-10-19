namespace cryptoEngine.Interfaces;

public interface IResources
{
    List<string> GetAlphabet();
    List<string> GetCaesarSymetricKey();
    Dictionary<string, string> ConstructChessboard();
}