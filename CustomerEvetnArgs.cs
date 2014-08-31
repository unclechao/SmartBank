using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartBank
{
    public class CustomerEvetnArgs : EventArgs
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
            set { balance = value; }
        }
        #endregion
    }
}
