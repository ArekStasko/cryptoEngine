using System.Collections.Concurrent;
using cryptoEngine.Interfaces;

namespace cryptoEngine;

public class Resources : IResources
{
    public List<string> GetAlphabet() => new() {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z", " ", ",", "."};
    public List<string> GetCaesarSymetricKey() => new() {"z","y","x","w","v","u","t","s","r","q","p","o","n","m","l","k","j","i","h","g","f","e","d","c","b","a", "", "", ""};
    
    public ConcurrentDictionary<string, string> ConstructChessboard()
    {
        var alphabet = GetAlphabet();
        var chessboard = new ConcurrentDictionary<string, string>() { };
        int counter = 0;
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                chessboard.TryAdd($"{i}{j}", alphabet[counter]);
                counter++;
            }     
        }       
        return chessboard;
    }
}