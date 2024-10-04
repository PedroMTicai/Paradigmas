namespace Practice1
{
    public class PoliceCar : Vehicle, IRegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private PoliceDepartment policedepartment; 
        private bool pursuit;
        private bool hasRadar;
        public string Plate { get; private set; }

        public PoliceCar(string plate, PoliceDepartment policedepartment, bool hasRadar = false) : base(typeOfVehicle)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            this.policedepartment = policedepartment;
            this.policedepartment.AddPoliceCar(this);
            this.pursuit = false;
            this.hasRadar = hasRadar;
            Plate = plate;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (hasRadar)
            {
                if (isPatrolling)
                {
                    if (vehicle is IRegisteredVehicle registeredVehicle)
                    {
                        speedRadar.TriggerRadar(vehicle);
                        string meassurement = speedRadar.GetLastReading();
                        Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                        if (meassurement.Contains("Catched"))
                        {
                            DetectInfraction(registeredVehicle.Plate);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("Vehicle has no plate."));
                    }
                }
                else
                {
                    Console.WriteLine($"{this.Plate} has no active radar.");
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"{this.Plate} has no radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage($"{this.Plate} started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{this.Plate} is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage($"{this.Plate} stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{this.Plate} was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }

        public void Pursue(string vehicleLicensePlate)
        {
            pursuit = true;
            Console.WriteLine(WriteMessage($"{this.Plate} is pursuing vehicle with plate {vehicleLicensePlate}."));
        }

        public void StopPursue()
        {
            pursuit = false;
            Console.WriteLine(WriteMessage($"{this.Plate} stopped pursuing"));
        }

        public void DetectInfraction(string plate)
        {
            policedepartment.NotifyPoliceCars(plate);
            Pursue(plate);
        }
    }
}