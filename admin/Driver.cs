using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin

{
    internal class Driver
    {
        private string driverName = "";
        private string driverSurName = "";
        private string carType = "";
        private string carNumber = "";
        private bool isActive = false;
        private string password = "";

        public Driver(string driverName, string driverSurName, string carType, string carNumber, string password)
        {
            this.driverName = driverName;
            this.driverSurName = driverSurName;
            this.carType = carType;
            this.carNumber = carNumber;
            this.password = password;
            isActive = true;
        }
        public string DriverName
        {
            get { return this.driverName; }
            set { driverName = value; }
        }
        public string DriverSurName
        {
            get { return driverSurName; }
            set { driverSurName = value; }
        }

        public string CarType
        {
            get { return carType; }
            set { carType = value; }
        }

        public string CarNumber
        {
            get { return carNumber; }
            set { carNumber = value; }
        }


        public void DeActive()
        {
            isActive = false;
        }
        public bool Exist()
        {
            return isActive;
        }



        public string Password
        {
            get { return password; }

        }

    }
}
