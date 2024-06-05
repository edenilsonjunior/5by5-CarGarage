using Controllers;
using Models;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintTitle();

            bool insert = new CarController().InsertAll(GenerateCars());
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
            List<string> carNames = new() { "Toyota", "Honda", "Ford", "Chevrolet", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Nissan", "Hyundai", "Mazda", "Subaru", "Kia", "Lexus", "Volvo" };

            List<string> carColors = new() { "Vermelho", "Azul", "Verde", "Preto", "Branco", "Prata" };
            var list = new List<Car>();

            while (list.Count < 30)
            {
                PrintTitle();

                int yearManufacture = GetRandomYear(start: 1990, end: 2025);
                Car car = new()
                {
                    Plate = GetRandomPlate(list),
                    Name = GetRandomName(carNames),
                    YearManufacture = yearManufacture,
                    YearModel = GetRandomYear(start: yearManufacture, end: 2025),
                    Color = GetRandomColor(carColors)
                };

                list.Add(car);

                Console.WriteLine("Carro inserido:\n" + car.ToString());
                Console.WriteLine($"Falta(m) {30 - list.Count} Carro(s)!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            return list;
        }


        static string GetRandomPlate(List<Car> list)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string plate = "";

            for (int i = 0; i < 3; i++)
                plate += letters[new Random().Next(0, letters.Length)];

            plate += "-";

            for (int i = 0; i < 4; i++)
                plate += new Random().Next(0, 9).ToString();

            // If exists plate in list, generate another plate
            if (list.Any(x => x.Plate.Equals(plate)))
                return GetRandomPlate(list);

            return plate;
        }


        static string GetRandomName(List<string> carNames) => carNames[new Random().Next(carNames.Count)];


        static int GetRandomYear(int start, int end) => new Random().Next(start, end);


        static string GetRandomColor(List<string> carColors) => carColors[new Random().Next(carColors.Count)];

        static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");
        }
    }
}
