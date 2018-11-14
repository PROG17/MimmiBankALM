using MimmiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimmiBank.ViewModels
{
    public class DepositWithdrawViewModel
    {
        public Account Account { get; set; }

        public double Sum { get; set; }
    }
}
