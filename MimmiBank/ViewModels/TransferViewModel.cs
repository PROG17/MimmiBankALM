using MimmiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimmiBank.ViewModels
{
    public class TransferViewModel
    {
        public Account AccountOne { get; set; }
        public Account AccountTwo { get; set; }
        public double Sum { get; set; }
    }
}
