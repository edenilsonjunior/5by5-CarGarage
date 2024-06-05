using Controllers;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");

            var controller = new CarController();

            var list = controller.GetAll();
            bool result = controller.InsertAll(list);

            if (result)
                Console.WriteLine("Dados inseridos com sucesso!");
            else
                Console.WriteLine("Falha ao inserir os dados!");
        }
    }
}
