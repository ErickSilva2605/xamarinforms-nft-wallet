namespace NFTWallet.Models
{
    public class NftModel : BaseModel
    {
        public string Image { get; set; }
        public double Price { get; set; }
        public UserModel Owner { get; set; }
    }
}
