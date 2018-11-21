using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimmiBank.Repository;
using MimmiBank.ViewModels;

namespace MimmiBank.Controllers
{
    public class TransferController : Controller
    {

        private IBankRepository _bankRepository;

        public TransferController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }


        public IActionResult TransferToAccount()
        {
            var model = new TransferViewModel();
            return View(model);
        }

        public IActionResult Transfer(TransferViewModel model)
        {
            var customers = _bankRepository.GetListOfCustomers();
            var account1 = customers.SelectMany(i => i.Accounts.Where(x => x.Accountnumber.Equals(model.AccountOne.Accountnumber))).SingleOrDefault();
            var account2 = customers.SelectMany(i => i.Accounts.Where(x => x.Accountnumber.Equals(model.AccountTwo.Accountnumber))).SingleOrDefault();

            if (account1 == null  || account2 == null )
            {
                ModelState.AddModelError("", "Invalid account number, please enter a new one");
                model.AccountOne = null;
                model.AccountTwo = null;
                return View("TransferToAccount", model);
            }

            if (model.Sum == 0)
            {
                ModelState.AddModelError("", "Please enter an amount higher than 0 kr");
                model.AccountOne = null;
                model.AccountTwo = null;
                return View("TransferToAccount", model);
            }

            if (model.Sum > account1.Balance)
            {
                ModelState.AddModelError("", "The amount is higher than the account balance, please enter a new amount!");
                model.AccountOne = null;
                model.AccountTwo = null;
                return View("TransferToAccount", model);
            }

            if (account1 == null || account1 == null)
            {
                ModelState.AddModelError("", "The account number doesn't exist.");
                model.AccountOne = null;
                model.AccountTwo = null;
                return View("TransferToAccount", model);
            }
            else
            {
                _bankRepository.TransferBetweenAccounts(model.Sum, account1, account2);
                model.AccountTwo.Balance = account2.Balance;

                return View("TransferToAccount", model);

            }

        }
    }
}