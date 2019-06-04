using System.Collections.Generic;
using iPlantino.Mobile.Models;
using Xamarin.Forms;

namespace iPlantino.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly List<PageListModel> pageList;
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            pageList = new List<PageListModel>
            {
                new PageListModel { Name = "Configurar Bluetooth", Controller = "BLEListPage" },
                new PageListModel { Name = "Configurar Wi-Fi", Controller = "" }
            };

            ListView.ItemsSource = pageList;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = pageList[e.ItemIndex];

            switch (item.Controller)
            {
                case "BLEListPage":
                    Navigation.PushAsync(new BLEListPage());
                    break;
                default:
                    break;
            }
        }
    }
}
