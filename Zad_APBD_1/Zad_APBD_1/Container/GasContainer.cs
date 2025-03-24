namespace Zad_APBD_1;

public class GasContainer: Container, IHazardNotifier
{
    private const char ContainerType = 'G';
    
    public double Pressure { get; set; }

    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
    
    public GasContainer(
        double maxWeight, double height, double width, double containerWeight, double pressure, Cargo? cargo
    ) : base(maxWeight, height, width, containerWeight, cargo)
    {
        Type = ContainerType;
        Pressure = pressure;
    }

    public override void Unload(double mass)
    {
        if (CargoWeight == 0)
            throw new ContainerEmptyException("Nic do załadowania");

        if (CargoWeight - mass < CargoWeight * 0.05)
        {
            NotifyHazard("Nie da się wypuścić aż tyle gazu!");
        }

        CargoWeight -= mass;
    }
    
    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, CargoWeight: {CargoWeight}, MaxWeight: {MaxWeight}, Number: {Number}, " +
               $"GasType: {Cargo.Name}, Pressure: {Pressure}";
    }
}