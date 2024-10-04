namespace Practice1
{
    internal class Program
    {
        static void Main()
        {
            City city = new City();
            Console.WriteLine(city.WriteMessage("Created"));

            PoliceDepartment department = city.GetPoliceDepartment();
            Console.WriteLine(department.WriteMessage("Created"));

            Taxi taxi1 = new Taxi("TAXI123");
            Taxi taxi2 = new Taxi("TAXI456");
            city.RegisterTaxi(taxi1);
            city.RegisterTaxi(taxi2);

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", department, true);  
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", department, true);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", department);
            Scooter scooter1 = new Scooter();
            department.AddPoliceCar(policeCar1);
            department.AddPoliceCar(policeCar2);
            department.AddPoliceCar(policeCar3);

            policeCar3.UseRadar(taxi1);

            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar3.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            city.RemoveTaxi(taxi1);
        }
    }
}