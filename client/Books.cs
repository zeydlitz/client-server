using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace client
{
    public class CollectionBook
    {
        public List<Books> books;
        public Books this[int index]
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
    public class Books
    {
        public class Book
        {
            private string name;
            private string path;
            private byte[] array;
            private Image im;

            public byte[] ar { get=>array; set=>array=value; }
            public string Name_file { get => name; set => name = value; }
            public string Path { get => path; set => path = value; }
            public Image Im { get => im; set => im = value; }

            //<TextBlock Margin = "5" Text="{Binding Value, StringFormat={}{0:C}}" FontSize="17" FontFamily="Franklin Gothic Medium"/>
            public Book(string name, string path, byte[] array)
            {
                this.name = name;
                this.path = path;
                this.array = array;
                im = ByteArrayImageToImage(this.array);

            }

            public Image ByteArrayImageToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }

        }
    }
}
