using System;
using System.Collections.Generic;
using System.Numerics;

[Serializable]
public class PlayerInfo
{
    public int money;
    public int NbAnnimal;
    public List<SaveAnnimal> inventory = new List<SaveAnnimal>();
}

[Serializable]
public struct SaveAnnimal
{
    public string Name;
    public int Age;
    public float ActualHunger, ActualThirst, ActualTiredness, AgeTime;
    public float x, y, z;
    public bool FirstTime;
}