namespace Zad_APBD_1;

public class LiquidContainer : Container, IHazardNotifier
{
    private const char ContainerType = 'L';

    public LiquidContainer(
        double maxWeight, double height, double width, double containerWeight, Cargo? cargo
    ) : base(maxWeight, height, width, containerWeight, cargo)
    {
        Type = ContainerType;
    }
    
    public override void Load(double mass)
    {
        if (Cargo.IsHazardous)
            LoadHazardous(mass);
        else 
            LoadSafe(mass);
    }

    private void LoadHazardous(double mass)
    {
        if (mass == 0)
            throw new OverfillException("Nic do załadowania");
        if (CargoWeight + mass > MaxWeight * 0.5)
            NotifyHazard("W przypadku cieczy niebezpiecznych można załadować jedynie 50% wagi kontenera!!");
        CargoWeight += mass;
    }

    private void LoadSafe(double mass)
    {
        if (mass == 0)
            throw new OverfillException("Nic do załadowania");
        if (CargoWeight + mass > MaxWeight * 0.9)
            throw new OverfillException("W przypadku zwykłych płynów można załadować jedynie 90% wagi pojemnika!");
        CargoWeight += mass;
    }

    public void NotifyHazard(string message)
    {
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, CargoWeight: {CargoWeight}, MaxWeight: {MaxWeight}, Number: {Number}, " +
               $"LiquidType: {Cargo.Name}, IsHazardous: {Cargo.IsHazardous}";
    }
}