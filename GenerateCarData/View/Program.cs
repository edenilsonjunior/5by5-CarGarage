using Controllers;
using Models;

namespace View
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var list = GenerateCars();

            bool insert = new CarController().InsertAll(list);

            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");
            if (!insert)
                Console.WriteLine("Erro ao inserir os carros.");
            else
            {
                Console.WriteLine("Todos os carros foram inseridos com sucesso!");
                Console.WriteLine("O arquivo Json está disponível em: 'pasta do projeto/Documents'");
            }
        }


        static List<Car> GenerateCars()
        {
            var list = new List<Car>();
            var random = new Random();
            var carNames = new List<string> { "Toyota", "Honda", "Ford", "Chevrolet", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Nissan", "Hyundai" };
            var carColors = new List<string> { "Vermelho", "Azul", "Verde", "Preto", "Branco", "Prata" };


            for (int i = 1; i <= 30; i++)
            {
                Console.Clear();
                Console.WriteLine("====|Garagem de carros|=====");

                string plate = GenerateRandomPlate(random);
                string name = GenerateRandomName(random, carNames);

                int yearManufacture = GenerateRandomYear(random, start: 1990, end: 2025);
                int yearModel = GenerateRandomYear(random, start: yearManufacture, end: 2025);

                string color = GenerateRandomColor(random, carColors);

                var car = new Car(plate, name, yearManufacture, yearModel, color);
                list.Add(car);

                Console.WriteLine("Carro inserido:\n" + car.ToString());
                Console.WriteLine($"Falta(m) {30 - i} Carro(s)!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            return list;
        }


        static string GenerateRandomPlate(Random r)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string plate = "";

            for (int i = 0; i < 3; i++)
                plate += letters[r.Next(0, letters.Length)];

            plate += "-";

            for (int i = 0; i < 4; i++)
                plate += r.Next(0, 9).ToString();

            return plate;
        }


        static string GenerateRandomName(Random r, List<string> carNames) => carNames[r.Next(carNames.Count)];


        static int GenerateRandomYear(Random r, int start, int end) => r.Next(start, end);


        static string GenerateRandomColor(Random r, List<string> carColors) => carColors[r.Next(carColors.Count)];

    }
}
