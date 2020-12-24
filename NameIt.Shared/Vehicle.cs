using System;
using System.Runtime.Serialization;

namespace NameIt
{
    [Serializable]
    public class Vehicle
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public string Country { get; set; }
        public string Author { get; set; }
        public BodyType BodyStyle { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public BNGColor[] Colors { get; set; }
        public int PerformanceClass { get; set; }
        public string DerbyClass { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Brand", Brand, typeof(string));
            info.AddValue("Years", new[] {YearStart, YearEnd}, typeof(int[]));
            info.AddValue("Country", Country, typeof(string));
            info.AddValue("Author", Author, typeof(string));
            info.AddValue("Body Style", BodyStyle.ToString(), typeof(string));
            info.AddValue("Value", BodyStyle.ToString(), typeof(string));
        }
    }
    
    [Serializable]
    public class VehicleTechnicalDetails
    {
        public Transmission Transmission { get; set; }
        public Drivetrain Drivetrain { get; set; }
        public float KmZeroToHundred { get; set; }
        public float MilesZeroToHundred { get; set; }
        public string BreakingG { get; set; }
        public float TopSpeed { get; set; }
        public float Torque { get; set; }
        public int PeakRPMTorque { get; set; }
        public int PeakRPMPower { get; set; }
        public float WeightPowerRatio { get; set; }
        public int OffRoadScore { get; set; }
        public PropulsionType Propulsion { get; set; }
        public FuelType FuelType { get; set; }
        public InductionType InductionType { get; set; }
        public int PerformanceClass { get; set; }
    }

    public enum Drivetrain
    {
        RearWheelDrive,
        AllWheelDrive,
        FrontWheelDrive,
        FourWheelDrive
    }

    public enum Transmission
    {
        Manual,
        Automatic
    }

    public enum BodyType
    {
        Sedan,
        SUV,
        Wagon,
        Coupe,
        Hatchback,
        PickupTruck,
        SemiTruck,
        Truck,
        Compact,
        Subcompact,
        SportCoupe,
        Van,
        Crossover,
        Minivan,
        Roadster,
        Convertible,
        StationWagon,
        Bus
    }

    public enum InductionType
    {
        Turbo,
        NA
    }

    public enum PropulsionType
    {
        ICE,
        Electric
    }

    public enum FuelType
    {
        Gasoline,
        Diesel,
        Battery,
        Ethanol
    }
}