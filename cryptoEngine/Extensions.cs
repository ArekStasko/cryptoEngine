using cryptoEngine.Interfaces;
using cryptoEngine.CaesarCipher;
using cryptoEngine.PolybiusChessboard;
using Microsoft.Extensions.DependencyInjection;

namespace cryptoEngine;

public delegate IEncryptionFunctionAsync AsynchronousFunctionsResolver(FunctionsTypes type);
public delegate IEncryptionFunction FunctionsResolver(FunctionsTypes type);
public static class Extensions
{
    public static void SetupEncryptionFunctions(this IServiceCollection services)
    {
        services.AddTransient<ICaesarCipherFunctionAsync, CaesarCipherFunctionAsync>();
        services.AddTransient<IPolybiusChessboardFunctionAsync, PolybiusChessboardFunctionAsync>();

        services.AddScoped<AsynchronousFunctionsResolver>(services => type =>
        {
            switch (type)
            {
                case FunctionsTypes.CaesarCipher:
                    return services.GetRequiredService<ICaesarCipherFunctionAsync>();
                default:
                    return null;
            }
        });
        
        services.AddScoped<FunctionsResolver>(services => type =>
        {
            switch (type)
            {
                case FunctionsTypes.PolybiusChessboard:
                    return services.GetRequiredService<IPolybiusChessboardFunctionAsync>();
                default:
                    return null;
            }
        });
    }

    public static void SetupEncryptionResources(this IServiceCollection services)
    {
        services.AddScoped<IResources, Resources>();
    }
}