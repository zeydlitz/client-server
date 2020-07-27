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
    public class Book 
    {

        
        private Image im;

        protected string name_file;
        protected string path;
        protected string imarray;

        public string Name_file { get => name_file; set => name_file = value; }
        public string Path { get => path; set => path = value; }
        public string ImArray { get => imarray; set => imarray = value; }
        public Image Img { get => im; set => im = value; }
        private BitmapImage bitmapImage;
        public BitmapImage Bit { get => bitmapImage; set => bitmapImage = value; }

        //<TextBlock Margin = "5" Text="{Binding Value, StringFormat={}{0:C}}" FontSize="17" FontFamily="Franklin Gothic Medium"/>
 
        public Book(string name_file, string path, string imArray)
        {
            this.name_file = name_file;
            this.path = path;
            this.imarray = imArray;
            im = ByteArrayImageToImage(Convert.FromBase64String(this.imarray));
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
