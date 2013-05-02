using System;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PictureTagging.Resources;

namespace PictureTagging
{
    public partial class SelectedPicturePage : PhoneApplicationPage
    {
        public SelectedPicturePage()
        {
            InitializeComponent();

            BuildLocalizedApplicationBar();
        }

        // Load data when user navigates to page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            base.OnNavigatedTo(e);

            var index = "";
            if (NavigationContext.QueryString.TryGetValue("index", out index))
            {
                SetImage(int.Parse(index));
            }
        }

        private void SetImage(int index)
        {
            var refPic = App.ViewModel.Pictures[index].Id;
            var bitmap = new BitmapImage();
            bitmap.SetSource(refPic.GetImage());
            FullPicture.Source = bitmap;
        }

        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            var appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/favs.addto.png", UriKind.Relative))
                {
                    Text = AppResources.AppBarAddTag
                };
            ApplicationBar.Buttons.Add(appBarButton);
        }
    }
}