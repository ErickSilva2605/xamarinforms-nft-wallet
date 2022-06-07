using Xamarin.CommunityToolkit.ObjectModel;

namespace NFTWallet.Models
{
    public class BaseModel : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
