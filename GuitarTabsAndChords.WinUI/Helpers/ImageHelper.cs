using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarTabsAndChords.WinUI.Helpers
{
    public class ImageHelper
    {
        public static byte[] GetDefaultProfileImage()
        {
            Image defaultimage = Properties.Resources.DefaultProfilePicture;
            var ms = new MemoryStream();
            defaultimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        public static byte[] GetDefaultAlbumArt()
        {
            Image defaultimage = Properties.Resources.DefaultAlbumArt;
            var ms = new MemoryStream();
            defaultimage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
