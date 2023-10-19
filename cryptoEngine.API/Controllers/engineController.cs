using cryptoEngine.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cryptoEngine.API.Controllers;

[Route("api/engine/[action]")]
[ApiController]
public class engineController : Controller
{
    private FunctionsResolver _functionsResolver;
    
    public engineController(FunctionsResolver functionsResolver)
    {
        _functionsResolver = functionsResolver;
    }
    
    [HttpGet(Name = "CaesarCipherEncrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> CaesarCipherEncrypt(string message)
    {
        var function = _functionsResolver(FunctionsTypes.CaesarCipher);
        var result = await function.Encrypt(message);
        return Ok(result);
    }
    
    [HttpGet(Name = "CaesarCipherDecrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> CaesarCipherDecrypt(string message)
    {
        var function = _functionsResolver(FunctionsTypes.CaesarCipher);
        var result = await function.Decrypt(message);
        return Ok(result);
    }
    
    [HttpGet(Name = "PolybiusChessboardEncrypt")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> PolybiusChessboardEncrypt(string message)
    {
        var function = _functionsResolver(FunctionsTypes.PolybiusChessboard);
        var result = await function.Encrypt(message);
        return Ok(result);
    }
}