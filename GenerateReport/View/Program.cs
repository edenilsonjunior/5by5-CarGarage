using Controllers;
using Models;
using System.Net.WebSockets;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====|Garagem de carros|=====");

            ReportController controller = new();

            Console.WriteLine("Carros com status ativos:");
            var filterByStatus = controller.GetByStatus();
            foreach (var item in filterByStatus)
            {
                Console.WriteLine(item);
            }
            controller.GenerateXml(filterByStatus, "filtradoPeloStatus");


            Console.WriteLine("Carros com cor vermelha:");

            var filterByColor = controller.GetByRedColor();
            foreach (var item in filterByColor)
            {
                Console.WriteLine(item);
            }
            controller.GenerateXml(filterByColor, "filtradoPelaCor");

            Console.WriteLine("Carros fabricados em 2010 e 2011:");
            var filterByYear = controller.GetByYear();
            foreach (var item in filterByYear)
            {
                Console.WriteLine(item);
            }
            controller.GenerateXml(filterByYear, "filtradoPeloAno");
        }
    }
}
