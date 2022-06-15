namespace NFTWallet.Models
{
    public class TrendModel
    {
        public double Value { get; set; }
        public double Percentage { get; set; }
        public bool IsRising { get; set; }
        public UserModel User { get; set; }
    }
}
