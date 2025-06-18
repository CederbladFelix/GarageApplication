namespace GarageApplication.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private static HashSet<string> _usedRegistrationNumbers = new();
        private static readonly Random _random = new();
        private string _registrationNumber = "";


        public string RegistrationNumber
        {
            get => _registrationNumber;
            protected set => _registrationNumber = value.ToUpper();
        }

        public int NumberOfWheels { get; }
        public VehicleType Type { get; }
        public VehicleColor Color { get; }

        public void SetRegistrationNumber(string regNumber)
        {
            _registrationNumber = regNumber.ToUpper();
            _usedRegistrationNumbers.Add(_registrationNumber);
        }


        protected Vehicle(VehicleType type, VehicleColor color, int numberOfWheels)
        {
            RegistrationNumber = GenerateUniqueRegistrationNumber();
            Type = type;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        private static string GenerateUniqueRegistrationNumber()
        {
            string registrationNumber;
            do
            {
                registrationNumber = GenerateRandomRegNumber();
            }
            while (!_usedRegistrationNumbers.Add(registrationNumber));
            return registrationNumber;
        }

        private static string GenerateRandomRegNumber()
        {
            var letters = new string(Enumerable.Range(0, 3)
                .Select(_ => (char)_random.Next('A', 'Z' + 1))
                .ToArray());

            var numbers = _random.Next(0, 1000).ToString("D3");

            return letters + numbers;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Registration number: {RegistrationNumber}, Color: {Color}, Number of Wheels: {NumberOfWheels}";
        }
    }

}
