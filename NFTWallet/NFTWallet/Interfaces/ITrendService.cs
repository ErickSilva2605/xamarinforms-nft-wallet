using NFTWallet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Interfaces
{
    public interface ITrendService
    {
        Task<ICollection<TrendModel>> GetTrendsAsync();
    }
}
