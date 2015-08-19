using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
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
            ChangeButtonStatus();
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
            finally
            {
                ChangeButtonStatus();
            }
        }

        private async void Twitter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kullanici = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Twitter);
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
            finally
            {
                ChangeButtonStatus();
            }
        }

        private void Cikis_Click(object sender, RoutedEventArgs e)
        {
            App.MobileService.Logout();
            ChangeButtonStatus();
        }

        private void ChangeButtonStatus()
        {
            if (App.MobileService.CurrentUser != null)
            {
                btnFacebook.IsEnabled = false;
                btnTwitter.IsEnabled = false;
                btnCikis.IsEnabled = true;
                lblDurum.Text = "Durum: Giriş Yapıldı";
            }
            else
            {
                btnFacebook.IsEnabled = true;
                btnTwitter.IsEnabled = true;
                btnCikis.IsEnabled = false;
                lblDurum.Text = "Durum: Giriş Yapılmadı";
            }
            lblDurum.SetValue(AutomationProperties.NameProperty, lblDurum.Text);
        }

    }
}
