using System.Collections.Generic;

namespace NFTWallet.Models
{
    public class ProfileModel
    {
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Likes { get; set; }
        public UserModel User { get; set; }
        public ICollection<NftModel> UserNfts { get; set; }
    }
}
