using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimmiBank.Repository;
using MimmiBank.ViewModels;

namespace MimmiBank.Controllers
{
    public class AccountController : Controller
    {
        private IBankRepository _bankRepository;

        public AccountController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }


        public IActionResult DepositWithDraw()
        {

            var model = new DepositWithdrawViewModel();
            return View(model);

        }

        public IActionResult Deposit(DepositWithdrawViewModel model)
        {
            var customers = _bankRepository.GetListOfCustomers();

            var account = customers.SelectMany(i => i.Accounts.Where(x => x.Accountnumber.Equals(model.Account.Accountnumber))).SingleOrDefault();

            if (account == null)
            {
                ModelState.AddModelError("", "The account number doesn't exist.");
                model.Account = null;
                return View("DepositWithdraw", model);
            }
            else
            {
                _bankRepository.DepositAccount(model.Sum, account);
                model.Account.Balance = account.Balance;

                return View("DepositWithdraw", model);

            }

        }
        public IActionResult Withdraw(DepositWithdrawViewModel model)
        {
            var customers = _bankRepository.GetListOfCustomers();

            var account = customers.SelectMany(i => i.Accounts.Where(x => x.Accountnumber.Equals(model.Account.Accountnumber))).SingleOrDefault();

            if (account == null)
            {
                ModelState.AddModelError("", "The account number doesn't exist.");
                model.Account = null;
                return View("DepositWithdraw", model);
            }
            var result = _bankRepository.WithdrawAccount(model.Sum, account);

            if (result)
            {
                model.Account.Balance = account.Balance;
                return View("DepositWithdraw", model);

            }
            else
            {
                ModelState.AddModelError("", "There's not enough money on account to withdraw.");
                model.Account.Balance = account.Balance;
                return View("DepositWithdraw", model);

            }

        }
    }
}