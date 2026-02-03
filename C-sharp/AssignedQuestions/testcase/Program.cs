using NUnit.Framework;
using System;

namespace BankAccountTests
{
  
    public class UnitTest
    {
    
        public void Test_Deposit_ValidAmount()
        {
            
            Program account = new Program(100m);

            
            account.Deposit(50m);

        
            Assert.AreEqual(150m, account.Balance);
        }

    
        public void Test_Deposit_NegativeAmount()
        {
        
            Program account = new Program(100m);

           
            var ex = Assert.Throws<Exception>(() => account.Deposit(-10m));

            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

     
        public void Test_Withdraw_ValidAmount()
        {
        
            Program account = new Program(200m);

           
            account.Withdraw(50m);

        
            Assert.AreEqual(150m, account.Balance);
        }

       
        public void Test_Withdraw_InsufficientFunds()
        {
            
            Program account = new Program(100m);

            
            var ex = Assert.Throws<Exception>(() => account.Withdraw(150m));

            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
