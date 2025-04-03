using AutoGenMauiPlayground.ViewModels;

namespace AutoGenMauiPlayground
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}