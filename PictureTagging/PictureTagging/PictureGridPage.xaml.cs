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
    }
}