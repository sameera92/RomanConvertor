using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanNumberConvertor;

namespace RomanNumberConvertor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Roman Number:");
            string? romanNumber = Console.ReadLine();
            var romanconvertor = new RomanNumberConvertor();
            var output = romanconvertor.ConvertRomanToInt(romanNumber);

            Console.WriteLine($"{romanNumber} is {output}");

        }
    }
}
