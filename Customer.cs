using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SmartBank
{
    public class Customer 
    {
        #region Attributes
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int balance;
        public int Balance
        {
            get { return balance; }
        }
        #endregion

        //Constructor
        public Customer(string idNumber, string fullName)
        {
            id = idNumber;
            name = fullName;
        }

        public bool Save(string customerId, int amount)
        {
            return Bank.GetInstance().Save(customerId, amount);
        }

        public bool Draw(string customerId, int amount)
        {
            return Bank.GetInstance().Draw(customerId, amount);
        }

        public bool Register(string customerId, string name)
        {
            return Bank.GetInstance().Register(customerId, name);
        }

        public bool closeAccount(string customerId, string name)
        {
            return Bank.GetInstance().closeAccount(customerId, name);
        }
    }
}
