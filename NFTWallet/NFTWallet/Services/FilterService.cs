using NFTWallet.Helpers;
using NFTWallet.Interfaces;
using NFTWallet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFTWallet.Services
{
    public class FilterService : IFilterService
    {
        public async Task<ICollection<FilterModel>> GetFiltersAsync(string language)
        {
            return await Task.Run(() =>
                language == Constants.CULTURE_ENGLISH ? GetFiltersEnglish() : GetFiltersPortuguese()
            );
        }

        private ICollection<FilterModel> GetFiltersPortuguese()
        {
            var filters = new List<FilterModel>();

            filters.Add(new FilterModel { Id = 1, Name = "TODOS", Selected = true });
            filters.Add(new FilterModel { Id = 2, Name = "JOGOS" });
            filters.Add(new FilterModel { Id = 3, Name = "CONCEITUAL" });
            filters.Add(new FilterModel { Id = 4, Name = "FINANÇA" });
            filters.Add(new FilterModel { Id = 5, Name = "PUNKS" });
            filters.Add(new FilterModel { Id = 6, Name = "ILUSTRAÇÃO" });
            filters.Add(new FilterModel { Id = 7, Name = "GIFS" });

            return filters;
        }

        private ICollection<FilterModel> GetFiltersEnglish()
        {
            var filters = new List<FilterModel>();
            filters.Add(new FilterModel { Id = 1, Name = "ALL", Selected = true });
            filters.Add(new FilterModel { Id = 2, Name = "GAMES" });
            filters.Add(new FilterModel { Id = 3, Name = "CONCEPTUAL" });
            filters.Add(new FilterModel { Id = 4, Name = "FINANCE" });
            filters.Add(new FilterModel { Id = 5, Name = "PUNKS" });
            filters.Add(new FilterModel { Id = 6, Name = "ILLUSTRATION" });
            filters.Add(new FilterModel { Id = 7, Name = "GIFS" });

            return filters;
        }
    }
}
