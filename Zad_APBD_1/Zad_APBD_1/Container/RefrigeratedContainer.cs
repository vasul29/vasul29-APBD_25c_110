namespace Zad_APBD_1;

public class RefrigeratedContainer: Container, IHazardNotifier
{
    private const char ContainerType = 'C';
    private double ContainerTemperature { get; set; }
    
    public RefrigeratedContainer(
        double maxWeight, double height, double width, double containerWeight, 
        double containerTemperature, Cargo? cargo
    ) : base(maxWeight, height, width, containerWeight, cargo)
    {
        Type = ContainerType;
        ContainerTemperature = containerTemperature;

        if (cargo.Temperature < containerTemperature)
        {
            throw new WrongContainerTemperature("Temperatura kontenera jest wyższa niż temperatura ładunku");
        }
    }
    
    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
    
    public string CargoName {
        get => Cargo.Name;
    }

    public double CargoTemperature {
        get => Cargo.Temperature;
    }

    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, CargoWeight: {CargoWeight}, MaxWeight: {MaxWeight}, Number: {Number}, " +
               $"Cargo: {CargoName}, CargoTemperature: {CargoTemperature}, " +
               $"ContainerTemperature: {ContainerTemperature}";
    }
}