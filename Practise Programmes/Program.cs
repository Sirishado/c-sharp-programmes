using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practise_Programmes
{
    class Program
    {
        
        public void Getstring()
        {
            Console.WriteLine("Hello World!");
        }
        public async Task GetData()
        {
            try
            {
                string Sentence = "This Is Practise Program";
                Console.WriteLine(Sentence.Contains("Practise"));
                Console.WriteLine(Sentence.Contains("example"));
            }
            catch(Exception ex)
            {
                throw ;
            }
        }
        public  async Task<Bank> GetDetails()
        {
            try
            {
                Bank bank = new();
                bank.Id = Guid.NewGuid();
                bank.BankName = "ICICI";
                bank.BranchName = "Hyderabad";
                bank.Name = "Sirisha";
                bank.AccountNumber = "123456";
                List<Bank> lstbanks = new();
                lstbanks.Add(bank);
                var data =  (from banks in lstbanks.AsQueryable()
                                  where banks.Name == "Sirisha"
                                  select new Bank()
                                  {
                                      Id = banks.Id,
                                      BranchName = banks.BranchName,
                                      BankName = banks.BankName,
                                      Name = banks.Name,
                                      AccountNumber = banks.AccountNumber


                                  }).ToList();
                var bankDetails = lstbanks.Where(k => k.BranchName == "Hyderabad").Select(i => i).Skip(0).Take(1).FirstOrDefault();
                return  bank;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Months Details()
        {
            try
            {

                Months months = new();
                months.MonthNames = "Jan,Feb,March,April".Split(',').ToList();
                months.WeekNames = "sunday,Monday,Friday,Saturday".Split(',').ToList();
                return months;
            }
            catch (Exception e)
            {
                throw;
            }
        }



        static void Main(string[] args)
        {
           
        }
    }
}
