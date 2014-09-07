namespace BankModelTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BankModel;
    using System.Transactions;

    [TestClass]
    public class BankConsoleClient
    {
        [TestMethod]
        public void CanMakeATransaction()
        {
            var db = new BankATM();
            var account = new CardAccount()
            {
                CardCash = 300,
                CardNum = "1234567898",
                CardPin = "1234"
            };

            int amount = 100;

            using (db)
            {
                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
                TransactionScope currentTransaction = new TransactionScope(TransactionScopeOption.Required, tranOptions);

                using (currentTransaction)
                {
                    if (IsCardNumberValid(account.CardNum) && IsCardPinValid(account.CardPin) && account.CardCash >= amount)
                    {
                        account.CardCash -= amount;

                        var currentHistory = new TransactionsHistory();
                        currentHistory.CardNumber = account.CardNum;
                        currentHistory.TransactionDate = DateTime.Now;
                        currentHistory.Ammount = account.CardCash;

                        db.TransactionsHistories.Add(currentHistory);
                        db.SaveChanges();
                        currentTransaction.Complete();

                        Assert.AreEqual(200, account.CardCash);
                    }
                }
            }
        }
        
        private static bool IsCardNumberValid(string cardNumber)
        {
            if (cardNumber.Length == 10 && cardNumber[0] != 0) return true;

            return false;
        }

        private static bool IsCardPinValid(string cardPin)
        {
            if (cardPin.Length == 4) return true;

            return false;
        }

    }
}
