using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;

namespace PictureTagging
{
    public partial class SelectedPicturePage : PhoneApplicationPage
    {
        public SelectedPicturePage()
        {
            InitializeComponent();
        }

        // Load data when user navigates to page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            SetImage();
        }

        private void SetImage()
        {
            var refPic = App.ViewModel.Pictures[0].Id;
            var bitmap = new BitmapImage();
            bitmap.SetSource(refPic.GetImage());
            FullPicture.Source = bitmap;
        }
    }
}