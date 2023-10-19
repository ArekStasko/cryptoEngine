using cryptoEngine.Interfaces;

namespace cryptoEngine.PolybiusChessboard;

public class PolybiusChessboardFunction : IPolybiusChessboardFunction
{
    private readonly IResources _resources;
    
    public PolybiusChessboardFunction(IResources resources)
    {
        _resources = resources;
    }
    public Task<string> Encrypt(string messageToEncrypt)
    {
        var chessboard = _resources.ConstructChessboard();
        throw new NotImplementedException();
    }

    public Task<string> Decrypt(string messageToDencrypt)
    {
        throw new NotImplementedException();
    }
}