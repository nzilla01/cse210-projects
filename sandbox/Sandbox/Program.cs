using System;

class Program
{
    public class Account 
    {
        public int _balance = 0;
        public void Deposite(int amount )
        {
            _balance = _balance + amount;
 
        }
    }

static void Main(string[] args)
{
    Account account = new Account();
    account.Deposite(100);
    Console.WriteLine("Balance: " + account._balance);
}

}