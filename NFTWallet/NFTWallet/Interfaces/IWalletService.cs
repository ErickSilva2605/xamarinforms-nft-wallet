using NFTWallet.Models;
using System.Threading.Tasks;

namespace NFTWallet.Interfaces
{
    public interface IWalletService
    {
        Task<WalletModel> GetWalletAsync(string language);
    }
}
