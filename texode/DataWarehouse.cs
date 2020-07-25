using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string name;
        public string path;
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        InformationCard()
        {
            name = "Swift";
            path = "book\\Swift";
        }
        InformationCard(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
    }
}
