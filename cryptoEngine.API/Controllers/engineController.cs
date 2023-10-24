using cryptoEngine.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cryptoEngine.API.Controllers;

[Route("api/engine/[action]")]
[ApiController]
public class engineController : Controller
{
    private AsynchronousFunctionsResolver _asynchronousFunctionsResolver;
    private FunctionsResolver _functionsResolver;
    
    public engineController(AsynchronousFunctionsResolver asynchronousFunctionsResolver, FunctionsResolver functionsResolver)
    {
        _asynchronousFunctionsResolver = asynchronousFunctionsResolver;
        _functionsResolver = functionsResolver;
    }
    
    [HttpGet(Name = "CaesarCipherEncrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> CaesarCipherEncrypt(string message)
    {
        var function = _asynchronousFunctionsResolver(FunctionsTypes.CaesarCipher);
        var result = await function.Encrypt(message);
        return Ok(result);
    }
    
    [HttpGet(Name = "CaesarCipherDecrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> CaesarCipherDecrypt(string message)
    {
        var function = _asynchronousFunctionsResolver(FunctionsTypes.CaesarCipher);
        var result = await function.Decrypt(message);
        return Ok(result);
    }
    
    [HttpGet(Name = "PolybiusChessboardEncrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public IActionResult PolybiusChessboardEncrypt(string message)
    {
        var function = _functionsResolver(FunctionsTypes.PolybiusChessboard);
        var result = function.Encrypt(message);
        return Ok(result);
    }
    
    [HttpGet(Name = "PolybiusChessboardDecrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public IActionResult PolybiusChessboardDecrypt(string message)
    {
        var function = _functionsResolver(FunctionsTypes.PolybiusChessboard);
        var result = function.Decrypt(message);
        return Ok(result);
    }
}