using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace LocalStorageData.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddUser : Page
    {
        Models.StorageManager StorageManage = new Models.StorageManager();
        Models.LocationManager LocationManage = new Models.LocationManager();

        public AddUser()
        {
            this.InitializeComponent();

            cmbCountries.ItemsSource = LocationManage.Countries;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var user = new ViewModels.User()
            {
                Id = Guid.NewGuid(),
                NameSurname = txtNameSurname.Text,
                CountryId = ((ViewModels.Location)cmbCountries.SelectedItem).Id,
                CityId = ((ViewModels.Location)cmbCities.SelectedItem).Id,
                Job = txtJob.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                SaveDate = DateTime.Now
            };
            if (StorageManage.Add(user))
            {
                StorageManage.Save();
                await new MessageDialog("Kayıt Başarıyla Tamamlandı.", "LocalStorageSample").ShowAsync();
            }
            else
                await new MessageDialog("Bu üye önceden kayıtlı!", "LocalStorageSample").ShowAsync();
        }

        private void AllUsers_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void cmbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var country = (ViewModels.Location)cmbCountries.SelectedItem;
            if (country == null) return;
            cmbCities.ItemsSource = LocationManage.Cities.Where(c => c.RelationId == country.Id);
        }
    }
}
