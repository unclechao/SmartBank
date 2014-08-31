using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartBank
{
    public delegate void DelegateClassEventHandle(object sender, CustomerEvetnArgs e);
    public class Bank
    {
        public event DelegateClassEventHandle CustomerMoneyChangedEvent;
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        private static readonly Bank p_instance = new Bank();
        private Bank()
        {
            if (CustomerMoneyChangedEvent == null)
            {
                CustomerMoneyChangedEvent += Bank_CustomerMoneyChangedEvent;
            }
        }

        //Make sure only one bank exist
        public static Bank GetInstance()
        {
            return p_instance;
        }
        //customerTable to record customer info, info likes: Id,<Name, account>
        private static Dictionary<string, KeyValuePair<string, int>> customerTable = new Dictionary<string, KeyValuePair<string, int>>();

        //Notify customer the money changed
        void Bank_CustomerMoneyChangedEvent(object sender, CustomerEvetnArgs e)
        {
            string customerId = sender as string;
            e.Id = customerId;
            e.Balance = customerTable[e.Id].Value;
            Console.WriteLine("Account Changed! {0} :{1}", e.Id, e.Balance);
        }

        /// <summary>
        /// Save money
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Save(string customerId, int amount)
        {
            bool flag;
            string existCustomerId = customerTable.Keys.SingleOrDefault(i => i == customerId);
            if (!string.IsNullOrEmpty(existCustomerId))
            {
                int currentSaving = customerTable[existCustomerId].Value;
                currentSaving += amount;
                customerTable[existCustomerId] = new KeyValuePair<string, int>(existCustomerId, currentSaving);
                if (CustomerMoneyChangedEvent != null)
                {
                    Bank_CustomerMoneyChangedEvent(customerId, new CustomerEvetnArgs());
                }
                flag = true;
            }
            else
            {
                //can't find customer
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Draw money
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Draw(string customerId, int amount)
        {
            bool flag;
            string existCustomerId = customerTable.Keys.SingleOrDefault(i => i == customerId);
            if (!string.IsNullOrEmpty(existCustomerId))
            {
                int currentSaving = customerTable[existCustomerId].Value;
                currentSaving -= amount;
                customerTable[existCustomerId] = new KeyValuePair<string, int>(existCustomerId, currentSaving);
                if (CustomerMoneyChangedEvent != null)
                {
                    Bank_CustomerMoneyChangedEvent(customerId, new CustomerEvetnArgs());
                }
                flag = true;
            }
            else
            {
                //can't find customer
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Register a new customer
        /// </summary>
        /// <param name="customerId">customwe id</param>
        /// <param name="name">customer name</param>
        /// <returns></returns>
        public bool Register(string customerId, string name)
        {
            bool flag;
            string existCustomerId = customerTable.Keys.SingleOrDefault(i => i == customerId);
            if (string.IsNullOrEmpty(existCustomerId))
            {
                customerTable.Add(customerId, new KeyValuePair<string, int>(name, 0));
                flag = true;
            }
            else
            {
                //customer already exist
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Close a exist costomer
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool closeAccount(string customerId, string name)
        {
            bool flag;
            string existCustomerId = customerTable.Keys.SingleOrDefault(i => i == customerId);
            if (!string.IsNullOrEmpty(existCustomerId))
            {
                customerTable.Remove(existCustomerId);
                flag = true;
            }
            else
            {
                //customer not exist
                flag = false;
            }
            return flag;
        }
    }
}
