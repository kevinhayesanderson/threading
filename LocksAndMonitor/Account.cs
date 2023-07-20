namespace LocksAndMonitor
{
    internal class Account
    {
        private Object withdrawLock = new object();
        private int balance;
        private Random random = new Random();

        public Account(int initialBalance)
        {
            balance = initialBalance;
        }

        private int Withdraw(int amount)
        {
            if (balance < 0)
            {
                throw new Exception("Not enough balance");
            }
            Monitor.Enter(withdrawLock);
            try
            {
                //lock (withdrawLock)
                //{
                //    if (balance >= amount)
                //    {
                //        Console.WriteLine($"Amount withdrawn: {amount}");
                //        balance = balance - amount;
                //    }
                //}
                if (balance >= amount)
                {
                    Console.WriteLine($"Amount withdrawn: {amount}");
                    balance = balance - amount;
                }
            }
            finally
            {
                Monitor.Exit(withdrawLock);
            }
            return balance;
        }

        public void WithdrawRandomly()
        {
            for (int i = 0; i < 100; i++)
            {
                var balance = Withdraw(random.Next(2000, 5000));
                Console.WriteLine($"Balance left: {balance}");
            }
        }
    }
}