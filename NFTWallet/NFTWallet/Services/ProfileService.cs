using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class ProfileService : IProfileService
    {
        public async Task<ICollection<NftModel>> GetOwnershipNftsAsync()
        {
            return await Task.Run(() =>
                GetOwnershipNfts()
            );
        }

        public async Task<ProfileModel> GetProfileAsync()
        {
            return await Task.Run(() =>
                GetProfile()
            );
        }

        private ProfileModel GetProfile()
        {
            Random random = new Random();

            return new ProfileModel 
            {
                Followers = random.Next(10000),
                Following = random.Next(10000),
                Likes = random.Next(10000),
                UserNfts = GetOwnershipNfts(),
                User = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_SIX, UserName = "@unkown", Cover = "profile_front_cover" }
            };
        }

        private ICollection<NftModel> GetOwnershipNfts()
        {
            Random random = new Random();
            var sales = new List<NftModel>();

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_one",
                    Name = "The Unkown",
                    Price = 1.2,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_ONE, UserName = "@unkown" }
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_two",
                    Name = "The Unkown",
                    Price = 2.3,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_TWO, UserName = "@unkown" }
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_three",
                    Name = "The Unkown",
                    Price = 4.1,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_THREE, UserName = "@unkown" }
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_four",
                    Name = "The Unkown",
                    Price = 1.0,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_FOUR, UserName = "@unkown" }
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_five",
                    Name = "The Unkown",
                    Price = 1.8,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_FIVE, UserName = "@unkown" }
                }
            );

            sales.Add(
                new NftModel
                {
                    Id = random.Next(9999),
                    Image = "nft_six",
                    Name = "The Unkown",
                    Price = 2.5,
                    Owner = new UserModel { Name = "Unkown", Image = Constants.USER_IMAGE_SIX, UserName = "@unkown" }
                }
            );

            return sales;
        }
    }
}
