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
                           Amount = 1259
                       },
                        new Account
                       {
                           Accountnumber = 98765,
                           Amount = 7609
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
                           Amount = 22998.4
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
                           Amount = 23.5
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
                           Amount = 488
                       },
                         new Account
                       {
                           Accountnumber = 67897,
                           Amount = 50000
                       },
                    }

                },
            };

            return customerList;
        }
    }
}
