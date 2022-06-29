using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_Programmes
{
   public class Encapsulation
    {
        
        int x;
        public Encapsulation(int iX)
        {
            this.x = iX;
        }
        public void MySquare()
        {
            int Calc = x * x;
            Console.WriteLine(Calc);
        }
    }
}
