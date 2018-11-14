using MimmiBank.Models;
using MimmiBank.Repository;
using System;
using Xunit;

namespace MimmiBank.Tests
{
    public class BankTests
    {
        [Fact]
        public void TestDepositToAccount()
        {
            var account = new Account();
            var bankrepository = new BankRepository();
            account.Balance = 100;
            account.Accountnumber = 1234;
            //Act
            bankrepository.DepositAccount(10.5, account);

            //Assert
            Assert.Equal(110.5, account.Balance);

        }

        [Fact]
        public void TestWithdrawFromAccount()
        {
            var account = new Account();
            var bankrepository = new BankRepository();
            account.Balance = 100;
            account.Accountnumber = 1234;


            //Act
            bankrepository.WithdrawAccount(10.5, account);


            //Assert
            Assert.Equal(89.5, account.Balance);
        }
        [Fact]
        public void TestWithdrawNotLowerThanAmount()
        {
            var account = new Account();
            var bankrepository = new BankRepository();
            account.Balance = 100;
            account.Accountnumber = 1234;

            //Act
            var result = bankrepository.WithdrawAccount(101, account);

            //Assert
            Assert.False(result);

        }
    }
}
