using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimmiBank.Models;
using MimmiBank.Repository;
using MimmiBank.ViewModels;

namespace MimmiBank.Controllers
{
    public class HomeController : Controller
    {
        private IBankRepository _bankRepository;
        
        public HomeController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var model = new StartpageViewModel()
            {
                Customers = _bankRepository.GetListOfCustomers()
            };



            return View(model);
        }

        
    }
}
