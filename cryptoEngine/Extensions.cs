using cryptoEngine.Interfaces;
using cryptoEngine.CaesarCipher;
using cryptoEngine.PolybiusChessboard;
using Microsoft.Extensions.DependencyInjection;

namespace cryptoEngine;

public delegate IEncryptionFunction FunctionsResolver(FunctionsTypes type);
public static class Extensions
{
    public static void SetupEncryptionFunctions(this IServiceCollection services)
    {
        services.AddTransient<ICaesarCipherFunction, CaesarCipherFunction>();
        services.AddTransient<IPolybiusChessboardFunction, PolybiusChessboardFunction>();

        services.AddScoped<FunctionsResolver>(services => type =>
        {
            switch (type)
            {
                case FunctionsTypes.CaesarCipher:
                    return services.GetRequiredService<ICaesarCipherFunction>();
                case FunctionsTypes.PolybiusChessboard:
                    return services.GetRequiredService<IPolybiusChessboardFunction>();
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