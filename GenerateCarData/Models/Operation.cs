namespace Models
{
    public class Operation
    {
        public readonly static string INSERT = "INSERT INTO Operation (Description) VALUES (@Description)";
        public readonly static string SELECT = "SELECT * FROM Operation";

        public int Id { get; set; }

        public string Description { get; set; }

        public Operation() { }

        public Operation(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
