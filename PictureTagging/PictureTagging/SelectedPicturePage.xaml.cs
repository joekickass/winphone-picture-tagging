using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

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
    }
}