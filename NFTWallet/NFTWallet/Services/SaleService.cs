using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class SaleService : ISaleService
    {
        public async Task<ICollection<ForSaleModel>> GetSalesAsync()
        {
            return await Task.Run(() =>
                GetSales()
            );
        }

        private ICollection<ForSaleModel> GetSales()
        {
            Random random = new Random();
            var sales = new List<ForSaleModel>();

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_one",
                    Name = "The Unkown",
                    Price = 1.2,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_one" }
                }
            );

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_two",
                    Name = "The Unkown",
                    Price = 2.3,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_two" }
                }
            );

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_three",
                    Name = "The Unkown",
                    Price = 4.1,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_three" }
                }
            );

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_four",
                    Name = "The Unkown",
                    Price = 1.0,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_four" }
                }
            );

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_five",
                    Name = "The Unkown",
                    Price = 1.8,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_five" }
                }
            );

            sales.Add(
                new ForSaleModel
                {
                    Id = random.Next(9999),
                    Image = "nft_six",
                    Name = "The Unkown",
                    Price = 2.5,
                    Owner = new OwnerModel { Name = "Unkown", Image = "user_six" }
                }
            );

            return sales;
        }
    }
}
