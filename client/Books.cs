using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;
using baseIC;

namespace client
{
    public class CollectionBook
    {
        public ObservableCollection<Book> books;
        public Book this[int index]
        {
            get
            {
                return books[index];
            }

            set
            {
                books[index] = value;
            }
        }

    }
    public class Book : InformationCard
    {

        
        private Image im;

   
        public Image Img { get => im; set => im = value; }
        private BitmapImage bitmapImage;
        public BitmapImage Bit { get => bitmapImage; set => bitmapImage = value; }

        //<TextBlock Margin = "5" Text="{Binding Value, StringFormat={}{0:C}}" FontSize="17" FontFamily="Franklin Gothic Medium"/>
 
        public Book(string name_file, string path, string imArray):base(name_file, path)
        {
            base.name_file = name_file;
            base.path = path;
            base.imarray = imArray;
            im = ByteArrayImageToImage(Convert.FromBase64String(base.imarray));
            bitmapImage = BitmapToImageSource((System.Drawing.Bitmap)im);

        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public Image ByteArrayImageToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


    }
}
