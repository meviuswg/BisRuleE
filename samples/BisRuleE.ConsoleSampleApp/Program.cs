using BisRuleE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBREConsoleSampleApp
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            var customer = new Customer() { Name = "Jos", Balance = 100M };

            var rule = new IBRERule(customer, "Name", IBREComparisonOperator.Equals, "Jos");

            var result = rule.Assert();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}