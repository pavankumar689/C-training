//dotnet new classlib -n DigitalWallet.Core --command to create this folder
namespace DigitalWallet.Core;

public class WalletInfo
{
    public static string GetAppName()
    {
        return "Digital Wallet System";
    }
}
