using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using PictureTagging.Model;

namespace PictureTagging
{
    public partial class PictureGridPage : PhoneApplicationPage
    {
        // Constructor
        public PictureGridPage()
        {
            InitializeComponent();

            // App context has the pictures model
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        
        // Load data when user navigates to page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Handle item selected
        private void PictureGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PictureGrid.SelectedItem == null)
            {
                return;
            }

            // TODO: Must be some easier way to get index of selected item
            var index = App.ViewModel.Pictures.IndexOf(PictureGrid.SelectedItem as PictureRef);
            NavigationService.Navigate(new Uri("/SelectedPicturePage.xaml?index=" + index, UriKind.Relative));

            // Reset selection
            PictureGrid.SelectedItem = null;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}