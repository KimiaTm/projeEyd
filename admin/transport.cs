using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    internal class Transport
    {
        private string transportAddress = "";
        private int indexProduct;
        public int indexDriver;
        public Transport(int indexProduct, int indexDriver, string transportAddress)
        {
            this.indexProduct = indexProduct;
            this.indexDriver = indexDriver;
            this.transportAddress = transportAddress;
        }


        public int IndexProduct
        {
            get { return indexProduct; }
            set { indexProduct = value; }
        }
        public int IndexDriver
        {
            get { return indexDriver; }
            set { indexDriver = value; }
        }
        public string TransportAddress
        {
            get { return transportAddress; }
            set { transportAddress = value; }
        }

    }
}
