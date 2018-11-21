using MimmiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimmiBank.Repository
{
    public interface IBankRepository
    {
        List<Customer> GetListOfCustomers();
        bool DepositAccount(double sum, Account account);
        bool WithdrawAccount(double sum, Account account);
        bool TransferBetweenAccounts(double sum, Account account1, Account account2);

    }
}
