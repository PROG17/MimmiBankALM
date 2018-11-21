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

        [Fact]
        public void Transfer_Test()
        {
            Account account1 = new Account();
            {
                account1.Accountnumber = 12345;
                account1.Balance = 1259;
            }

            Account account2 = new Account();
            {
                account2.Accountnumber = 23456;
                account2.Balance = 22998.4;
            }

            BankRepository bankRepository = new BankRepository();

            var expected = true;
            var actual = bankRepository.TransferBetweenAccounts(1000, account1, account2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransferHigherAmount_Test()
        {
            Account account1 = new Account();
            {
                account1.Accountnumber = 12345;
                account1.Balance = 1259;
            }

            Account account2 = new Account();
            {
                account2.Accountnumber = 23456;
                account2.Balance = 22998.4;
            }

            BankRepository bankRepository = new BankRepository();

            var expected = false;
            var actual = bankRepository.TransferBetweenAccounts(8000, account1, account2);

            Assert.Equal(expected, actual);
        }


    }
}
