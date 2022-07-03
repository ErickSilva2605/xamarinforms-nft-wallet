using System.Collections.Generic;

namespace NFTWallet.Models
{
    public class NftModel : BaseModel
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public UserModel Owner { get; set; }
        public ICollection<BidModel> LastBids { get; set; }
    }
}
