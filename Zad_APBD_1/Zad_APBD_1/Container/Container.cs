namespace Zad_APBD_1;

public class Container
{
    private static int _ContejnerIdStart = 0;
    public int Id { get; set; }
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double ContainerWeight { get; set; }
    public double MaxWeight { get; set; }
    
    public Cargo? Cargo { get; set; }
    
    protected char Type { get; set; }

    protected Container()
    {
        _ContejnerIdStart++;
        Id = _ContejnerIdStart;
    }

    protected Container(double maxWeight, double height, double width, double containerWeight, Cargo? cargo)
    {
        _ContejnerIdStart++;
        Id = _ContejnerIdStart;
        CargoWeight = 0;
        MaxWeight = maxWeight;
        Height = height;
        Width = width;
        ContainerWeight = containerWeight;
        Cargo = cargo;
    }
    
    public virtual void Load(double mass)
    {
        if (Weight + mass > MaxWeight)
        {
            throw new OverfillException("Za duże obciążenie");
        }
        CargoWeight += mass;
    }
    
    public double Weight
    {
        get => ContainerWeight + CargoWeight;
    }

    
    public virtual void Unload(double mass)
    {
        if (CargoWeight == 0)
            throw new ContainerEmptyException("Nic do rozładowania");

        if (CargoWeight - mass < 0)
        {
            throw new OverfillException("Za dużo rozładowania");
        }
        CargoWeight -= mass;
    }
    
    public string Number
    {
        get => $"KON-{Type}-{Id}";
    }
}