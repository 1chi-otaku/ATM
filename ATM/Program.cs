using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM ATM= new ATM();
            ATM.SetCheck(new DigitalCheck());
            ATM.SetCurrency(new Hryvna());

            short choice = -1;
            int currency = 0;
            while (choice != 0)
            {
                Console.Clear();
                ATM.PrintBalance();

                Console.WriteLine("0 - Exit\n1 - Top up\n2 - Withdraw\n3 - Change Currency\n4 - Change Check Properties");
                choice = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Enter summ to top up:");
                        ATM.TopUp(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Enter summ to withdraw:");
                        ATM.Decrease(Convert.ToDouble(Console.ReadLine()));
                        break;
                    case 3:
                        if(currency % 2 == 0)
                        {
                            ATM.SetCurrency(new Dollar());
                        }
                        else
                            ATM.SetCurrency(new Hryvna());
                        currency++;
                        Console.WriteLine("Success!");
                        break;
                    case 4:
                        Console.WriteLine("1 - No check\n2 - Digital Check\n3 - Non Digital Check");
                        choice = Convert.ToInt16(Console.ReadLine());
                        switch (choice)
                        {
                        case 1:
                            ATM.SetCheck(null);
                            break;
                        case 2:
                            ATM.SetCheck(new DigitalCheck());
                            break;
                        case 3:
                            ATM.SetCheck(new NonDigitalCheck());
                            break;
                            default:
                                break;
                        }
                        Console.WriteLine("Success!");
                        break;
                }
                Console.ReadLine();
            }



        }
    }
}
