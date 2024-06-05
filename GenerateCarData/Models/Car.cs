using Newtonsoft.Json;
using System.Xml.Linq;

namespace Models
{
    public class Car
    {
        public readonly static string INSERT = "INSERT INTO Car (Plate, Name, YearManufacture, YearModel, Color) VALUES (@Plate, @Name, @YearManufacture, @YearModel, @Color)";
        public readonly static string SELECT = "SELECT * FROM Car";

        [JsonProperty("plate")]
        public string Plate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("yearManufacture")]
        public int YearManufacture { get; set; }

        [JsonProperty("yearModel")]
        public int YearModel { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        public Car() { }

        public Car(string plate, string name, int yearManufacture, int yearModel, string color)
        {
            Plate = plate;
            Name = name;
            YearManufacture = yearManufacture;
            YearModel = yearModel;
            Color = color;
        }

        public override string ToString()
        {
            string str = "";
            str += $"Placa.............: {Plate}\n";
            str += $"Nome..............: {Name}\n";
            str += $"Ano de fabricação.: {YearManufacture}\n";
            str += $"Ano do modelo.....: {YearModel}\n";
            str += $"Cor...............: {Color}\n";
            return str;
        }

        public string ToXml()
        {
            var xml = new XElement("car",
                new XElement("plate", Plate),
                new XElement("name", Name),
                new XElement("yearManufacture", YearManufacture),
                new XElement("yearModel", YearModel),
                new XElement("color", Color)
            );

            return xml.ToString();
        }
    }
}



