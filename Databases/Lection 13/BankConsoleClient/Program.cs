namespace BankConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Transactions;

    using BankModel;

    public class Program
    {
        private static BankATM db;

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

        private static void InsertRecords()
        {
            var random = RandomGenerator.Instance;

            using (db)
            {
                for (int i = 0; i < 101; i++)
                {
                    var currentCardAccount = new CardAccount();

                    currentCardAccount.CardNum = random.GetRandomStringNumber(10);
                    currentCardAccount.CardPin = random.GetRandomStringNumber(4);
                    currentCardAccount.CardCash = random.GetRandomNumber(100, 1000);

                    db.CardAccounts.Add(currentCardAccount);

                    if (i % 10 == 0) db.SaveChanges();
                }
            }    
        }

        private static void WithdrawMoney(CardAccount account, int amount)
        {
            using(db)
            {
                var tranOptions = new TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
                TransactionScope currentTransaction = new TransactionScope(TransactionScopeOption.Required, tranOptions);

                using(currentTransaction)
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
                    }
                    else currentTransaction.Dispose();
                }
            }
        }

        public static void Main()
        {
            db = new BankATM();
            InsertRecords();
            CardAccount cardAccount = db.CardAccounts.Where(c => c.id == 93).First();

            WithdrawMoney(cardAccount, 30);
        }
    } 
}
