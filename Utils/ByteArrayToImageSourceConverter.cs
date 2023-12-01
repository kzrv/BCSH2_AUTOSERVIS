using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Kozyrev_Hriha_SP.Utils
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is byte[] byteArray)
                {
                    using (MemoryStream stream = new MemoryStream(byteArray))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CreateOptions =
                            BitmapCreateOptions.PreservePixelFormat;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();

                        if (image.CanFreeze) 
                        {
                            image.Freeze();
                        }

                        return image;
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error converting byte array to image: {ex.Message}\n{ex.StackTrace}");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
