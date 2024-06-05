using Controllers;
using Models;
using Newtonsoft.Json;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");

            List<Car> list;
            var controller = new CarController();
            bool result;

            try
            {
                list = controller.GetAll();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return;
            }

            try
            {
                result = controller.InsertAll(list);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return;
            }

            if(result)
                Console.WriteLine("Dados inseridos com sucesso!");
            else
                Console.WriteLine("Falha ao inserir os dados!");
                
        }
    }
}
