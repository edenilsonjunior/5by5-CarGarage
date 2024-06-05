using Controllers;
using Models;
namespace View
{
    internal class Program
    {
        static readonly Dictionary<int, Action> options = new()
        {
            {1, InsertCar},
            {2, InsertOperation},
            {3, InsertCarOperation},
        };


        static void Main(string[] args)
        {
            while (true)
            {
                int choose = Menu();

                if (choose == 0) break;

                if (options.ContainsKey(choose))
                    options[choose]();
                else
                    Console.WriteLine("Opcao invalida!");

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void InsertCar()
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");

            var c = new Car()
            {
                Plate = ReadString("Digite a placa do carro:"),
                Name = ReadString("Digite o nome do carro:"),
                YearManufacture = ReadInt("Digite o ano de fabricação:"),
                YearModel = ReadInt("Digite o ano do modelo:"),
                Color = ReadString("Digite a cor do carro:")
            };

            bool result = new CarController().Insert(c);

            if (result)
                Console.WriteLine("Carro adicionado com sucesso!");
        }


        static void InsertOperation()
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");

            Operation operation = new Operation()
            {
                Description = ReadString("Digite a descrição do serviço:")
            };

            bool result = new OperationController().Insert(operation);

            if (result)
                Console.WriteLine("Serviço adicionado com sucesso!");
        }

        static void InsertCarOperation()
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");

            var carList = new CarController().GetAll();

            Console.WriteLine("Carros disponiveis:");
            foreach (var item in carList)
                Console.WriteLine(item);


            var operationList = new OperationController().GetAll();

            Console.WriteLine("Serviços disponiveis:");
            foreach (var item in operationList)
                Console.WriteLine(item);

            string plate = ReadString("Digite a placa do carro:");
            int operationId = ReadInt("Digite o id do serviço:");

            var car = carList.Find(c => c.Plate.Equals(plate));

            if (car == null)
            {
                Console.WriteLine("Carro não encontrado!");
                return;
            }

            var operation = operationList.Find(o => o.Id.Equals(operationId));

            if (operation == null)
            {
                Console.WriteLine("Serviço não encontrado!");
                return;
            }

            var carOperation = new CarOperation()
            {
                Car = car,
                Operation = operation,
                Status = true
            };

            bool result = new CarOperationController().Insert(carOperation);

            if (result)
                Console.WriteLine("Serviço adicionado com sucesso!");
            else
                Console.WriteLine("Falha ao adicionar o serviço!");
        }

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("====|Garagem de carros|=====");
            Console.WriteLine("1- Cadastrar um novo carro");
            Console.WriteLine("2- Cadastrar um novo serviço");
            Console.WriteLine("3- Adicionar um serviço para um carro");

            return ReadInt("Digite sua resposta:");
        }

        static int ReadInt(string title)
        {
            int result;

            Console.WriteLine(title);
            Console.Write("R: ");
            var s = Console.ReadLine();

            while (!int.TryParse(s, out result))
            {
                Console.WriteLine("Resposta invalida! Tente novamente.");
                Console.WriteLine(title);
                Console.Write("R: ");
                s = Console.ReadLine();
            }

            return result;
        }

        static string ReadString(string title)
        {
            Console.WriteLine(title);
            Console.Write("R: ");

            string? str = Console.ReadLine();

            if (str == null)
            {
                return "";
            }

            return str;
        }

    }


}
