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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ComboBoxSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HashSet<ViewModels.Data> Countries = new HashSet<ViewModels.Data>()
        {
            new ViewModels.Data()
            {
                Id=1,
                Name= "Turkey"
            },
            new ViewModels.Data()
            {
                Id=2,
                Name="US"
            },
            new ViewModels.Data()
            {
                Id=3,
                Name ="UK"
            },
            new ViewModels.Data()
            {
                Id=4,
                Name = "Germany"
            }
        };

        HashSet<ViewModels.Data> Cities = new HashSet<ViewModels.Data>()
        {
            new ViewModels.Data()
            {
                Id=1,
                Name="Adana",
                RelationId =1
            },
            new ViewModels.Data()
            {
                Id=2,
                Name="Istanbul",
                RelationId=1
            },
            new ViewModels.Data()
            {
                Id=3,
                Name="Izmir",
                RelationId=1
            },
            new ViewModels.Data()
            {
                Id=4,
                Name="New York",
                RelationId=2
            },
            new ViewModels.Data()
            {
                Id=5,
                Name="Londra",
                RelationId=3
            },
            new ViewModels.Data()
            {
                Id=6,
                Name="Berlin",
                RelationId=4
            },
            new ViewModels.Data()
            {
                Id=7,
                Name="Frankfurt",
                RelationId=4
            }
        };

        HashSet<ViewModels.Data> Counties = new HashSet<ViewModels.Data>()
        {
            new ViewModels.Data()
            {
                Id=1,
                Name="Yuregir",
                RelationId=1
            },
            new ViewModels.Data()
            {
                Id=2,
                Name="Seyhan",
                RelationId=1
            },
            new ViewModels.Data()
            {
                Id=3,
                Name="Cukurova",
                RelationId=1
            },
            new ViewModels.Data()
            {
                Id=4,
                Name="Levent",
                RelationId=2
            },
            new ViewModels.Data()
            {
                Id=5,
                Name="Taksim",
                RelationId=2
            },
            new ViewModels.Data()
            {
                Id=6,
                Name="Buca",
                RelationId=3
            },
            new ViewModels.Data()
            {
                Id=7,
                Name="Bornova",
                RelationId=3
            },
            new ViewModels.Data()
            {
                Id=8,
                Name="Konak",
                RelationId=3
            },
            new ViewModels.Data()
            {
                Id=9,
                Name="Unknow #1",
                RelationId=4
            }
            ,
            new ViewModels.Data()
            {
                Id=10,
                Name="Unknow #2",
                RelationId=4
            },
            new ViewModels.Data()
            {
                Id=11,
                Name="Unknow #1",
                RelationId=5
            },
            new ViewModels.Data()
            {
                Id=12,
                Name="Unknow #2",
                RelationId=5
            },
            new ViewModels.Data()
            {
                Id=13,
                Name="Unknow #1",
                RelationId=6
            },
            new ViewModels.Data()
            {
                Id=14,
                Name="Unknow #1",
                RelationId=6
            },
            new ViewModels.Data()
            {
                Id=15,
                Name="Unknow #2",
                RelationId=6
            },
            new ViewModels.Data()
            {
                Id=16,
                Name="Unknow #1",
                RelationId=7
            },
            new ViewModels.Data()
            {
                Id=17,
                Name="Unknow #2",
                RelationId=7
            }
        };

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.cmbUlke.ItemsSource = Countries;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void cmbUlke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModels.Data selectedItem = (ViewModels.Data)this.cmbUlke.SelectedItem;
            if (selectedItem == null) return;
            cmbIl.ItemsSource = Cities.Where(c => c.RelationId == selectedItem.Id);
        }

        private void cmbIl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModels.Data selectedItem = (ViewModels.Data)this.cmbIl.SelectedItem;
            if (selectedItem == null) return;
            cmbIlce.ItemsSource = Counties.Where(c => c.RelationId == selectedItem.Id);
        }
    }
}
