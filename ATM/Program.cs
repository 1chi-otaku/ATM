using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM ATM= new ATM();

            Hryvna hryvna= new Hryvna();
            Dollar dollar = new Dollar();
            DigitalCheck digcheck = new DigitalCheck();
            NonDigitalCheck nondigcheck = new NonDigitalCheck();

            ATM.PrintBalance(hryvna);
            ATM.TopUp(100,digcheck);
            ATM.Decrease(20, nondigcheck);
            ATM.PrintBalance(dollar);
            ATM.PrintBalance(hryvna);





        }
    }
}
