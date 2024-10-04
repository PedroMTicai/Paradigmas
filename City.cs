namespace Practice1
{

    class City : IMessageWritter
    {
        private PoliceDepartment policeDepartment;
        private List<Taxi> taxis;

        public City()
        {
            policeDepartment = new PoliceDepartment();
            taxis = new List<Taxi>();
        }

        public void RegisterTaxi(Taxi taxi)
        {
            taxis.Add(taxi);
            Console.WriteLine($"Taxi with plate {taxi.Plate} registered in the city.");
        }

        public void RemoveTaxi(Taxi taxi)
        {
            if (taxis.Contains(taxi))
            {
                taxis.Remove(taxi);
                Console.WriteLine($"Taxi with plate {taxi.Plate} retired from the city.");
            }
        }

        public string WriteMessage(string message)
        {
            return $"{message}";
        }

        public List<Taxi> GetTaxis()
        {
            return taxis;
        }
        public PoliceDepartment GetPoliceDepartment()
        {
            return policeDepartment;
        }
    }
}