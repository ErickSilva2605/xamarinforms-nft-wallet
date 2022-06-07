using NFTWallet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Interfaces
{
    public interface IFilterService
    {
        Task<ICollection<FilterModel>> GetFiltersAsync(string language);
    }
}
