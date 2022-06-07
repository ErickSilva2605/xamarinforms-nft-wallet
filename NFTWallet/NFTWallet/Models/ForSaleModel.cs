namespace NFTWallet.Models
{
    public class ForSaleModel : BaseModel
    {
        public string Image { get; set; }

        public double Price { get; set; }

        public OwnerModel Owner { get; set; }
    }
}
