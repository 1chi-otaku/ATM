using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class ATM
    {
        private double summ;
        
        public ATM()
        {
            summ= 0;
        }
        public void Init()
        {
            Console.WriteLine("Enter summ:");
            summ = Convert.ToDouble(Console.ReadLine());
        }
        public void TopUp(double summ, ICheck pCheck)
        {
            if (summ < 0) throw new Exception("Top up summ can't be less than 0");
            if (pCheck != null)
                pCheck.Check(this.summ,summ, true);
            this.summ += summ;
        }
        public void Decrease(double summ, ICheck pCheck) {
            if (summ < 0) throw new Exception("Decrease summ can't be less than 0");
            if (pCheck != null)
                pCheck.Check(this.summ, summ, false);
            this.summ -= summ;
        }

        public void PrintBalance(ICurrency pCurrency)
        {
            summ = pCurrency.Convert(summ);
            pCurrency.CheckBalance(this.summ);
            
        }
    }  
}

    interface ICheck
    {
        void Check(double current_summ,double summm, bool type);
    }
    class DigitalCheck : ICheck { 
    
        public void Check(double current_summ, double summ, bool type) {
            Console.WriteLine("------Digital check------");
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("Prev. Summ - " + current_summ);
            if (type == true)
            {
                Console.WriteLine("Topped up! + " + summ);
                Console.WriteLine("Total: " + (current_summ + summ));
            }
            else
            {
                Console.WriteLine("Withdrawn - " + summ);
                Console.WriteLine("Total: " + (current_summ - summ));
            }
            Console.WriteLine("-----------------------------");
    }      
    }   
    class NonDigitalCheck : ICheck
    {
    public void Check(double current_summ, double summ, bool type)
    {
        Console.WriteLine("-----'Non Digital check'-----");
        Console.WriteLine(DateTime.Now.ToString());
        Console.WriteLine("Prev. Summ - " + current_summ);
        if (type == true)
        {
            Console.WriteLine("Topped up! + " + summ);
            Console.WriteLine("Total: " + (current_summ + summ));
        }
        else
        {
            Console.WriteLine("Withdrawn - " + summ);
            Console.WriteLine("Total: " + (current_summ - summ));
        }
        Console.WriteLine("-----------------------------");
    }
}

    interface ICurrency
    {
        void CheckBalance(double summ);
        double Convert(double summ);
    }

    class Hryvna:ICurrency
    {
        public void CheckBalance(double summ)
        {
        Console.WriteLine("Your current balance is " + Math.Round(summ,2) + " hryvnas!");
        }
        public double Convert(double summ)
        {
            return summ * 36.5686;
        }
}
    class Dollar:ICurrency
    {
        public void CheckBalance(double summ)
        {
            Console.WriteLine("Your current balance is " + Math.Round(summ, 2) + " dollars!");
        }
        public double Convert(double summ)
        {
            return summ * 0.0273;
        }
}

