namespace Models
{
    public class CarOperation
    {
        public readonly static string INSERT = "INSERT INTO CarOperation (CarPlate, OperationId, Status) VALUES (@CarPlate, @OperationId, @Status)";
        public readonly static string SELECT = "SELECT * FROM CarOperation";

        public Car Car { get; set; }
        public Operation Operation { get; set; }
        public bool Status { get; set; }

        public CarOperation() { }

        public CarOperation(int id, Car car, Operation operation, bool status)
        {
            Car = car;
            Operation = operation;
            Status = status;
        }
    }
}
