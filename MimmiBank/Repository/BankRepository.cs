using MimmiBank.Models;
using MimmiBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimmiBank.Repository
{
    public class BankRepository : IBankRepository
    {


        public bool DepositAccount(double sum, Account account)
        {
            account.Balance += sum;

            return true;

        }
        public bool WithdrawAccount(double sum, Account account)
        {
            if (sum > account.Balance)
            {
                return false;
            }
            account.Balance -= sum;
            return true;
        }


        public List<Customer> GetListOfCustomers()
        {
            var customerList = new List<Customer>()
            {
                new Customer()
                {
                    Customernumber = 1,
                    Name = "Mimmi Rundlöf",
                    Accounts = new List<Account>()
                    {
                       new Account
                       {
                           Accountnumber = 12345,
                           Balance = 1259
                       },
                        new Account
                       {
                           Accountnumber = 98765,
                           Balance = 7609
                       }
                    }
                },
                   new Customer()
                {
                    Customernumber = 2,
                    Name = "Helena Hedström",
                    Accounts = new List<Account>()
                    {
                       new Account
                       {
                           Accountnumber = 23456,
                           Balance = 22998.4
                       }
                    }

                },
                      new Customer()
                {
                    Customernumber = 3,
                    Name = "Feyona Thylander",
                    Accounts = new List<Account>()
                    {
                       new Account
                       {
                           Accountnumber = 34567,
                           Balance = 23.5
                       }
                    }

                },
                         new Customer()
                {
                    Customernumber = 4,
                    Name = "Test Person",
                    Accounts = new List<Account>()
                    {
                       new Account
                       {
                           Accountnumber = 67899,
                           Balance = 488
                       },
                         new Account
                       {
                           Accountnumber = 67897,
                           Balance = 50000
                       },
                    }

                },
            };

            return customerList;
        }
    }
}
