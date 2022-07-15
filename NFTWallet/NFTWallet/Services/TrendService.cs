using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class TrendService : ITrendService
    {
        public async Task<ICollection<TrendModel>> GetTrendsAsync()
        {
            return await Task.Run(() =>
                GetTrends()
            );
        }

        private ICollection<TrendModel> GetTrends()
        {
            Random random = new Random();
            var trends = new List<TrendModel>();

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_ONE, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_TWO, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_THREE, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_FOUR, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_FIVE, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_SIX, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_TWO, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            trends.Add(
                new TrendModel
                {
                    IsRising = random.Next() % 2 == 0 ? true : false,
                    Percentage = random.NextDouble(),
                    Value = random.NextDouble() * 1000,
                    User = new UserModel { Image = Constants.USER_IMAGE_TWO, Name = "Anonymous User", UserName = "@anonymous" }
                }
            );

            return trends;
        }
    }
}
