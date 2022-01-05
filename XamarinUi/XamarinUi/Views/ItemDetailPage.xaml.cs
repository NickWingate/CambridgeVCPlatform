using System.ComponentModel;
using Xamarin.Forms;
using XamarinUi.ViewModels;

namespace XamarinUi.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}