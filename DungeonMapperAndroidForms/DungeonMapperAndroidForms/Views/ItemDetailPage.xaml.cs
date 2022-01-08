using DungeonMapperAndroidForms.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DungeonMapperAndroidForms.Views
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