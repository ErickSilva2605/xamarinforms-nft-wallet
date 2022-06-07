namespace NFTWallet.Models
{
    public class FilterModel : BaseModel
    {
        private bool _selected;
        public bool Selected 
        {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }
    }
}
