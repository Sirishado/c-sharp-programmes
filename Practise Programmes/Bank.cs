using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_Programmes
{
    public class Bank
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
    }

    public class Months
    {
        public List<string> MonthNames { get; set; }
        public List<string> WeekNames { get; set; }
    }
}
