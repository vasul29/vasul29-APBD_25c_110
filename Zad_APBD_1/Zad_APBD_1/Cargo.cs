﻿namespace Zad_APBD_1;

public class Cargo
{
    public string Name { get; }
    public double Temperature { get; }
    public bool IsHazardous { get; }

    public Cargo(string name, double temperature)
    {
        Name = name;
        Temperature = temperature;
        IsHazardous = false;
    }

    public Cargo(string name, bool isHazardous)
    {
        Name = name;
        Temperature = 0;
        IsHazardous = isHazardous;
    }
    
    public Cargo(string name)
    {
        Name = name;
        Temperature = 0;
        IsHazardous = false;
    }

    public override string ToString()
    {
        return $"Cargo: {Name}, Temperature: {Temperature}, IsHazardous: {IsHazardous}";
    }
}