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
                ChartData = GetChartData(),
                Transactions = transactions
            };
        }

        private ChartModel GetChartData()
        {
            var chartValues = GetChartValues();

            return new ChartModel 
            {
                DateMax = chartValues.Select(s => s.Date).Max(),
                DateMin = chartValues.Select(s => s.Date).Min(),
                Interval = 2000,
                ValueMax = 10000,
                ValueMin = 0,
                Values = chartValues
            };
        }

        private ICollection<ChartValueModel> GetChartValues()
        {
            Random random = new Random();
            var chartValues = new List<ChartValueModel>();

            for (int i = 7; i >= 1; i--)
            {
                chartValues.Add(
                    new ChartValueModel
                    {
                        Date = DateTime.Now.AddDays(-i),
                        Value = random.Next(9000)
                    }
                );
            }

            return chartValues;
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
                        Date = DateTime.Now.Date.AddDays(-random.Next(7)).AddMinutes(random.Next(1440)),
                        IsDeposit = isDeposit,
                        Title = language == Constants.CULTURE_ENGLISH ? GetTitleEnglish(isDeposit) : GetTitlePortuguese(isDeposit)
                    }
                );
            }

            return transactions.OrderByDescending(o => o.Date.Date).ToList();
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
