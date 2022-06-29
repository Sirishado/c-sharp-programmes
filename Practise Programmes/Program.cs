using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise_Programmes
{
    class Account
    {

        public void Getstring()
        {
            Console.WriteLine("Hello World!");
        }
        public void GetData()
        {

            string Sentence = "This Is Practise Program";
            Console.WriteLine(Sentence.Contains("Practise"));
            Console.WriteLine(Sentence.Contains("example"));


        }
        //public  async Task<Bank> GetDetails()
        public void GetDetails()
        {
            try
            {
                Bank bank = new();
                bank.Id = Guid.NewGuid();
                bank.BankName = "ICICI";
                bank.BranchName = "Hyderabad";
                bank.Name = "Sirisha";
                bank.AccountNumber = "123456";
                Console.WriteLine("bank Account Number is :" + bank.AccountNumber);
                List<Bank> lstbanks = new();
                lstbanks.Add(bank);
                var data = (from banks in lstbanks.AsQueryable()
                            where banks.Name == "Sirisha"
                            select new Bank()
                            {
                                Id = banks.Id,
                                BranchName = banks.BranchName,
                                BankName = banks.BankName,
                                Name = banks.Name,
                                AccountNumber = banks.AccountNumber


                            }).ToList();
                Console.WriteLine(data.Select(k => k.Name).FirstOrDefault());
                var bankDetails = lstbanks.Where(k => k.BranchName == "Hyderabad").Select(i => i).Skip(0).Take(1).FirstOrDefault();
                Console.WriteLine(bankDetails.BankName);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void Details()
        {

            Months month = new Months();
            month.MonthNames = "jan,feb,march".Split(',').ToList();
            Console.WriteLine(month.MonthNames);

        }

        public void operators()
        {

            int num1 = 0; int num2 = 0;
            Console.WriteLine("Type first number, and then press enter");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type second number, and then press enter");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("a - Add");
            Console.WriteLine("s - Subtract");
            Console.WriteLine("m - Multiply");
            Console.WriteLine("d - Divide");
            Console.Write("Type Your option and then press enter ");
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
                    break;
            }

        }

        public void Getloops()
        {
            int[] a_array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (int items in a_array)//each array element present thre is no limit
            {
                Console.WriteLine(items);
            }
            for (int items = 0; items < 4; items++)//it execute statement until given condition is false
            {
                Console.WriteLine(a_array[items]);
            }
        }


        public string Number { get; set; }
        public static int AccountNumber = 123456789;
        public string Owner { get; set;}
        public decimal? Balance { get; set; }
        public decimal? AfterBalance { get; set; }
        public DateTime? date { get; set; }
        public DateTime? WithdrawalDate { get; set; }
       

      

    List<Transaction> lsttransactions = new List<Transaction>();



        public Account(string name)
        {
            int depositAmount = 0;int withdrawalAmount = 0;
            Console.WriteLine("Enter Deposit Amount");
            depositAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Withdrawal Amount");
            withdrawalAmount = Convert.ToInt32(Console.ReadLine());
            decimal? balance = 0;
            
            this.Owner = name;
            MakeDeposit(depositAmount, DateTime.UtcNow, "Initial Balance");
            this.Number = AccountNumber.ToString();
            foreach (var item in lsttransactions)
            {
                balance += item.Amount;
                
            }
            this.Balance = balance;

            MakeWithdraw(withdrawalAmount, DateTime.UtcNow, "Remaining Balance");
            balance = 0;
            foreach (var item in lsttransactions)
            {
                balance += item.Amount;

            }
            this.AfterBalance = balance;
            
            this.date = lsttransactions.Where(k => k.Note == "Initial Balance").Select(i => i.date).FirstOrDefault();
            this.WithdrawalDate = lsttransactions.Where(k => k.Note == "Remaining Balance").Select(i => i.date).FirstOrDefault();

        }

        public void MakeDeposit(decimal amount,DateTime date,string note)
        {
            if(amount<=0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount must be positive");
            }
            var deposit = new Transaction(amount,date,note);
            lsttransactions.Add(deposit);

        }
        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount must be positive");
            }
            if(Balance-amount<0)
            {
                throw new InvalidOperationException("Insufficient Balance for withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            lsttransactions.Add(withdrawal);

        }

        public void Join()
        {
            List<Transaction> lsttransaction = new List<Transaction>();
            var transaction = new Transaction(100, DateTime.UtcNow.Date, "Balance");
            lsttransaction.Add(transaction);
            List<Bank> lstbank = new List<Bank>();
            Bank bank = new Bank()
            {
                Id = Guid.NewGuid(),
                Name = "Sirisha",
                AccountNumber = "123",
                BankName = "HDFC",
                BranchName = "Hyderabad",
                Date = DateTime.UtcNow.Date


            };
            lstbank.Add(bank);
            var joindata = (from trans in lsttransaction
                        join banks in lstbank 
                        on trans.date equals banks.Date 
                        where banks.BranchName == "Hyderabad"
                        select new { trans, bank }).ToList();
            Console.WriteLine(joindata.Select(k => k.trans.Amount).FirstOrDefault());

            var leftjoindata = (from trans in lsttransaction
                                join banks in lstbank 
                                on trans.date equals banks.Date into ba
                                from ban in ba.DefaultIfEmpty()
                                where ban.BranchName == "Hyderabad"
                                select new { trans, bank }).ToList();
            Console.WriteLine(leftjoindata.Select(k => k.trans.Note).FirstOrDefault());





        }

        static void Main(string[] args)
        {
            Account account = new Account("Sirisha");
            //Console.WriteLine($"Dear {account.Owner} your Account Number is {account.Number} and Your Balance is {account.Balance}  on {account.date.Value}");
            //var number = account.Balance - account.AfterBalance;
            //Console.WriteLine($"Dear {account.Owner} your Account Number is {account.Number} and Your Withdrawal Balance is {number} on {account.WithdrawalDate.Value}");
            //Console.WriteLine($"Dear {account.Owner} your Account Number is {account.Number} and Your Remaining Balance is {account.AfterBalance} on {DateTime.UtcNow}");

            Console.WriteLine("Encapsulation mthod");
            Encapsulation encapsulation = new Encapsulation(20);
            encapsulation.MySquare();

            Console.WriteLine("Inheritence Method");

           Father fObj = new Father();
            fObj.FatherMethod();

            Child cObj = new Child();
            cObj.FatherMethod();
            cObj.ChildMethod();

            Console.WriteLine("Interface Method");

            test test = new test();
            test.methodA();
            test.methodB();

            Console.WriteLine("Method Overridind");

            hrDepart obj1 = new hrDepart();
            itDepart obj2 = new itDepart();
            financeDepart obj3 = new financeDepart();

            obj1.LeaderName();
            obj2.LeaderName();
            obj3.LeaderName();



            account.Join();
        }
    }
}
