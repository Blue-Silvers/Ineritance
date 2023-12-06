using System;
using System.Collections.Generic;

[Serializable]
public class PlayerInfo
{
    public int money;
    public int NbAnnimal;
}

[Serializable]
public struct SaveAnnimal
{
    public string Name;
    public int Age;
    public float ActualHunger, ActualThirst, ActualTiredness, AgeTime;
    public float x, y, z;
}