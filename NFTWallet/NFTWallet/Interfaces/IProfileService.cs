using NFTWallet.Models;
using System.Threading.Tasks;

namespace NFTWallet.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileModel> GetProfileAsync();
    }
}
