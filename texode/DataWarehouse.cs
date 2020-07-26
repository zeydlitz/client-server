using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Drawing;
namespace texode
{
    public class DataWarehouse
    {
        public List<InformationCard> books;
        public InformationCard this[int index]
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
        private string name;
        private string path;
        private byte[] im;
        
        public string Name_file { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public byte[] Im { get=> im; set=> im=value; }
    
  
        public InformationCard(string name, string path)
        {
            this.name = name;
            this.path = path;
            im = ImageToByteArray();

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
