namespace Practice1

{
    public class PoliceDepartment
    {
        private List<PoliceCar> policeCars;

        public PoliceDepartment()
        {
            policeCars = new List<PoliceCar>();
        }

        public void AddPoliceCar(PoliceCar policecar)
        {
            policeCars.Add(policecar);
            Console.WriteLine($"PoliceCar with plate {policecar.Plate} registered.");
        }
 

        public void NotifyPoliceCars(string plate)
        {
            Console.WriteLine($"Alert activated: Chasing vehicle with plate {plate}");
            foreach (var policeCar in policeCars)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.Pursue(plate);
                }
            }
        }
        public string WriteMessage(string message)
        {
            return $"{message}";
        }
    }
}
