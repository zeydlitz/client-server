using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
//using System.Drawing;
namespace baseIC
{
    public class DataWarehouse<T>
    {
        public List<T> books;
        public T this[int index]
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
    public class InformationCard
    {
        protected string name_file;
        protected string path;
        protected string imarray;

        public string Name_file { get => name_file; set => name_file = value; }
        public string Path { get => path; set => path = value; }
        public string ImArray { get => imarray; set => imarray = value; }

       
     
        public InformationCard(string name, string path)
        {
            this.name_file = name;
            this.path = path;
            string result = System.Text.Encoding.ASCII.GetString(ImageToByteArray());
        }

        public void SetImarray()
        {
            ImArray = Convert.ToBase64String(ImageToByteArray());
        }
        public byte[] ImageToByteArray()
        {
            Image im = Image.FromFile(path);
            using (var ms = new MemoryStream())
            {
                im.Save(ms, im.RawFormat);
                return ms.ToArray();
            }
        }


    }
}
