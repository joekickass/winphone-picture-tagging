using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Media;
using PictureTagging.Model;

namespace PictureTagging.ViewModels
{
    public class PictureViewModel
    {
        public PictureViewModel()
        {
            this.Pictures = new ObservableCollection<PictureRef>();
        }

        // This collection might not be efficient enough to list many pictures.
        // Virtualization is one way to solve it: http://blogs.msdn.com/b/albulank/archive/2009/11/12/data-and-ui-virtualization-in-wpf.aspx
        public ObservableCollection<PictureRef> Pictures { get; set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            using (var library = new MediaLibrary())
            {
                var pictureCollection = library.Pictures;

                var coll = pictureCollection.Select(CreatePicRef).ToList();
                foreach (var pictureRef in coll)
                {
                    Pictures.Add(pictureRef);
                }
                this.IsDataLoaded = true;
            }
        }

        private PictureRef CreatePicRef(Picture picture)
        {
            var bitmap = new BitmapImage();
            bitmap.SetSource(picture.GetThumbnail());
            var result = new PictureRef()
                {
                    Id = picture,
                    Src = bitmap
                };
            
            return result;
        }
    }
}
