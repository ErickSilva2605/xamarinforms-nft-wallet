using System.Collections.Generic;

namespace NFTWallet.Models
{
    public class WalletModel
    {
        public double Balance { get; set; }
        public double CryptoBalance { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; }
        public ChartModel ChartData { get; set; }
    }
}
