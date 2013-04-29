using System.Windows.Media;
using Microsoft.Xna.Framework.Media;

namespace PictureTagging.Model
{
    public class PictureRef
    {
        private Picture _id;

        public Picture Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    // TODO: Notify?
                }
            }
        }

        private ImageSource _src;

        public ImageSource Src
        {
            get
            {
                return _src;
            }
            set
            {
                if (_src != value)
                {
                    _src = value;
                    // TODO: Notify?
                }
            }
        }
    }
}
