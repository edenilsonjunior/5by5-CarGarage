using Controllers;
using Models;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====|Garagem de carros|=====");

            ReportController controller = new();

            Console.WriteLine("Carros com status ativos:");
            foreach (var item in controller.GetByStatus())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Carros com cor vermelha:");
            foreach (var item in controller.GetByRedColor())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Carros fabricados em 2010 e 2011:");
            foreach (var item in controller.GetByYear())
            {
                Console.WriteLine(item);
            }
        }
    }
}
