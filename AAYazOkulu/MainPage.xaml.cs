using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AAYazOkulu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        Microsoft.WindowsAzure.MobileServices.MobileServiceUser kullanici;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kullanici = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                if (kullanici == null)
                {
                    await new Windows.UI.Popups.MessageDialog("Kullanıcı Giriş Yapmadı!").ShowAsync();
                }
                else
                {
                    await new Windows.UI.Popups.MessageDialog("Giriş Yapıldı!").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                await new Windows.UI.Popups.MessageDialog(ex.Message).ShowAsync();
            }
        }
    }
}
