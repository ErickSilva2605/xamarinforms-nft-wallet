using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTWallet.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletContentView : ContentView
    {
        public WalletContentView()
        {
            InitializeComponent();
        }

        private void NumericalAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            double position = e.Position;

            if (!double.IsNaN(position))
            {
                if (position == 0)
                {
                    e.LabelContent = string.Empty;
                }
                else if (position < 1000000)
                {
                    //Thousands format 
                    e.LabelContent = position.ToString("#,K");
                }
                else if (e.Position < 1000000000)
                {
                    //Millions format 
                    e.LabelContent = position.ToString("#,,M");
                }
                else
                {
                    //Millions format 
                    e.LabelContent = position.ToString("#,,,.00B");
                }
            }
        }
    }
}