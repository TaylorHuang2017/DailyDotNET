/*
 * specification
 * 
 * the program requests: 
 *     current principal, curent interest rate, current monthly payment
 * and it displays for a variety of possible extra payment levels
 * - the amount of interest saved
 * - the payoff date
 * 
 */



using System;
using System.Diagnostics;

namespace V1
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal principal, interestRate, monthlyPayment;

            while (true)
            {
                principal = ReadData("Please enter the principal: ");
                interestRate = ReadData("Please enter the interest rate: ");
                monthlyPayment = ReadData("Please enter the monthly payment: ");
                if (principal * interestRate / 1200 < monthlyPayment) break;
                Console.WriteLine("The monthly payment must be lager than the interest! ");                
            }

            decimal totalInterest = TotalInterest(principal, interestRate, monthlyPayment);
            Console.WriteLine($"Total interest: {totalInterest:C2}");
            int payoffMonths = PayoffMonths(principal, interestRate, monthlyPayment);
            Console.WriteLine($"Payoff date is {DateTime.Now.AddMonths(payoffMonths): MMM yyyy}");
        }

        static decimal ReadData(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.WriteLine(prompt);
                string text = Console.ReadLine();
                bool success = decimal.TryParse(text, out result);
                if (!success)
                    Console.WriteLine("Please enter a decimal value. ");
                else if (result < 0.0m)
                    Console.WriteLine("Please enter a positive value. ");
                else
                    return result; 
                {

                }
            }
        }

        static decimal TotalInterest(decimal principal, decimal interestRate, decimal monthlyPayment)
        {
            decimal totalInterest = 0.0m;
            decimal currentPrincipal = principal;
            while (currentPrincipal > 0.0m)
            {
                decimal currentInterest = currentPrincipal * interestRate / 1200;
                decimal reduction = monthlyPayment - currentInterest;
                Debug.Assert(reduction > 0.0m);
                currentPrincipal = currentPrincipal - reduction;
                totalInterest = totalInterest + currentInterest;
            }
            return totalInterest;
        }

        static int PayoffMonths(decimal principal, decimal interestRate, decimal monthlyPayment)
        {
            int totalMonths = 0;
            decimal currentPrincipal = principal;
            while (currentPrincipal > 0.0m)
            {
                decimal currentInterest = currentPrincipal * interestRate / 1200;
                decimal reduction = monthlyPayment - currentInterest;
                Debug.Assert(reduction > 0.0m);
                currentPrincipal = currentPrincipal - reduction;
                totalMonths += 1;
            }
            return totalMonths;
        }
    }
}
