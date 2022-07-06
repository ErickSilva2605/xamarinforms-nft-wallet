using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class SaleService : ISaleService
    {
        public async Task<ICollection<NftModel>> GetSalesAsync(string language)
        {
            return await Task.Run(() =>
                GetSales(language)
            );
        }

        private ICollection<NftModel> GetSales(string language)
        {
            Random random = new Random();
            var sales = new List<NftModel>();
            string description = language == Constants.CULTURE_ENGLISH ? GetDescriptionEnglish() : GetDescriptionPortuguese();

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_one",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_ONE, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_two",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_TWO, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_three",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_THREE, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_four",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_FOUR, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_five",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_FIVE, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Description = description,
                    Image = "nft_six",
                    Name = "The Unkown",
                    Price = random.NextDouble() * 10,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_SIX, UserName = "@unkown" },
                    LastBids = GetLastBids()
                }
            );

            return sales;
        }

        private string GetDescriptionPortuguese()
        {
            return "É uma coleção única com a qual você pode farmar criptomoedas no metaverso. Você pode destruir castelos, capturar planetas, pvp contra gatos e slimes e pegar suas moedas.";
        }

        private string GetDescriptionEnglish()
        {
            return "Is an unique collection with which you can farm cryptocurrency in the metaverse. You can destroy castles, capture planets, pvp against cats and slimes and take their coins.";
        }

        private ICollection<BidModel> GetLastBids()
        {
            Random random = new Random();
            var lastBids = new List<BidModel>();

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_ONE,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_FOUR,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_THREE,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_ONE,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_SIX,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_FIVE,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_TWO,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_SIX,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_THREE,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            lastBids.Add(
                new BidModel
                {
                    Name = "Unkown",
                    Image = Constants.USER_IMAGE_FOUR,
                    CryptoAmount = (random.NextDouble() * 1000) / 1200,
                    Date = DateTime.Now.AddDays(-random.Next(10)).AddMinutes(random.Next(1440))
                }
            );

            return lastBids.OrderByDescending(o => o.Date).ToList();
        }
    }
}
