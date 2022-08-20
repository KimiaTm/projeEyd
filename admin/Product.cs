using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    internal class Product
    {
        private string id;
        private string barcode;
        private string name;
        private bool isActive;
        public Product(string id, string barcode,string name)
        {
            this.name = name;
            this.id = id;
            this.barcode = barcode;
            isActive = true;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public void DeActive()
        {
            isActive = false;
        }
        public bool Exist()
        {
            return isActive;
        }

    }
}
