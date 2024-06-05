namespace Models
{
    public class CarOperation
    {
        public readonly static string INSERT = "INSERT INTO CarOperation (CarPlate, OperationId, Status) VALUES (@CarPlate, @OperationId, @Status)";
        public readonly static string SELECT = "SELECT * FROM CarOperation";

        public int Id { get; set; }
        public Car Car { get; set; }
        public Operation Operation { get; set; }
        public bool Status { get; set; }

        public CarOperation() { }

        public CarOperation(int id, Car car, Operation operation, bool status)
        {
            Id = id;
            Car = car;
            Operation = operation;
            Status = status;
        }
    }
}
