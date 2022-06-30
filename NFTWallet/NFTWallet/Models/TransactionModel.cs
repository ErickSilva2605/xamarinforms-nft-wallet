using System;

namespace NFTWallet.Models
{
    public class TransactionModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CryptoAmount { get; set; }
        public bool IsDeposit { get; set; }
    }
}
