using NFTWallet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Interfaces
{
    public interface ISaleService
    {
        Task<ICollection<NftModel>> GetSalesAsync();
    }
}
