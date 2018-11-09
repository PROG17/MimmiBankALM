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

    }
}
