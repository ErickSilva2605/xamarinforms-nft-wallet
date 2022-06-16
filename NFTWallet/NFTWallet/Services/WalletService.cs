using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class WalletService : IWalletService
    {
        public async Task<WalletModel> GetWalletAsync(string language)
        {
            return await Task.Run(() =>
                GetWallet(language)
            );
        }

        private WalletModel GetWallet(string language)
        {
            var transactions = GetTransactions(language);
            var balance = Math.Abs(transactions.Where(w => w.IsDeposit == true).Sum(s => s.Amount)
                - transactions.Where(w => w.IsDeposit == false).Sum(s => s.Amount));

            return new WalletModel
            {
                Balance = balance,
                CryptoBalance = language == Constants.CULTURE_ENGLISH ? GetCryptoValueEnglish(balance) : GetCryptoValuePortuguese(balance),
                Transactions = transactions
            };
        }

        private ICollection<TransactionModel> GetTransactions(string language)
        {
            Random random = new Random();
            var transactions = new List<TransactionModel>();

            double amount;
            bool isDeposit;

            for (int i = 0; i < 20; i++)
            {
                amount = random.NextDouble() * 10000;
                isDeposit = random.Next() % 2 == 0 ? true : false;

                transactions.Add(
                    new TransactionModel
                    {
                        Amount = amount,
                        CryptoAmount = language == Constants.CULTURE_ENGLISH ? GetCryptoValueEnglish(amount) : GetCryptoValuePortuguese(amount),
                        Data = DateTime.Now.AddDays(-random.Next(DateTime.Now.DayOfYear)).AddMinutes(random.Next(10000)),
                        IsDeposit = isDeposit,
                        Title = language == Constants.CULTURE_ENGLISH ? GetTitleEnglish(isDeposit) : GetTitlePortuguese(isDeposit)
                    }
                );
            }

            return transactions;
        }

        private string GetTitlePortuguese(bool isDeposit)
        {
            return isDeposit ? "Recebidos" : "Enviado";
        }

        private string GetTitleEnglish(bool isDeposit)
        {
            return isDeposit ? "Received" : "Sent";
        }

        private double GetCryptoValuePortuguese(double value)
        {
            return value / 6100;
        }

        private double GetCryptoValueEnglish(double value)
        {
            return value / 1200;
        }
    }
}
