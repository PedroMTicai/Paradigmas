namespace Practice1
{
    public class Taxi : Vehicle, IRegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances.
        private static string typeOfVehicle = "Taxi";
        private bool isCarryingPassengers;
        public string Plate { get; private set; }

        public Taxi(string plate) : base(typeOfVehicle)
        {
            //Values of atributes are set just when the instance is done if not needed before.
            Plate = plate;
            isCarryingPassengers = false;
            SetSpeed(45.0f);
        }

        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage($"{this.Plate} starts a ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{this.Plate} is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage($"{this.Plate} finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{this.Plate} is not on a ride."));
            }
        }
    }
}