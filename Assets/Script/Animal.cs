using TMPro;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string Name;
    [SerializeField] protected int Age, Longetivity;
    public int price;
    [SerializeField] private TypeOfFoodEat typeOfFood;

    [SerializeField] protected float Hunger, Thirst, Tiredness;
    [SerializeField] protected float ActualHunger = 100, ActualThirst = 100, ActualTiredness = 100, AgeTime = 100;
    [SerializeField] GameObject HungerIcone, ThirstIcone, TirednessIcone;

    [SerializeField] protected bool Sleep;

    public int Spawnpoint;

    public bool FirstTime = true;

    public float ActualHungerP, ActualThirstP;

    public GameObject thisAnimal;

    protected void Start()
    {
        if (FirstTime == true)
        {
            Tiredness = Random.Range(20, 200);
            ActualHunger = Hunger;
            ActualThirst = Thirst;
            ActualTiredness = Tiredness;
            Sleep = false;
        }
    }

    protected void Update()
    {
        //age
        AgeTime -= Time.deltaTime;
        if (AgeTime < 0)
        {
            Age++;
            AgeTime = 100;
        }
        if (Age >= Longetivity)   
        {
            AnnimalDie();
            ZooManager.Instance.DieAge(Name);
            Destroy(gameObject);
        }

        //need feed
        ActualHunger -= Time.deltaTime;
        if (ActualHunger < 0)
        {
            AnnimalDie();
            ZooManager.Instance.DieHunger(Name);
            Destroy(gameObject);
        }
        else if (ActualHunger < 50) 
        { 
            HungerIcone.SetActive(true);
        }
        else { HungerIcone.SetActive(false);}
        ActualHungerP = ActualHunger;

        //need water
        ActualThirst -= Time.deltaTime;
        if (ActualThirst < 0)
        {
            AnnimalDie();
            ZooManager.Instance.DieThirst(Name);
            Destroy(gameObject);
        }
        else if (ActualThirst < 50)
        {
            ThirstIcone.SetActive(true);
        }
        else {  ThirstIcone.SetActive(false);}
        ActualThirstP = ActualThirst;

        //need sleep
        if (!Sleep) 
        {
            ActualTiredness -= Time.deltaTime;
            if (ActualTiredness < 0)
            {
                Sleep = true;
                TirednessIcone.SetActive(true);
                Invoke("SleepTime", 20f);
            }
        }

    }

    public void SetName(string name)
    {
        Name = name;
    }

    protected void SleepTime()
    {
        Tiredness = Random.Range(20, 200);
        ActualTiredness = Tiredness;
        Sleep = false;
        TirednessIcone.SetActive(false);
    }


    public void AnnimalDie()
    {
        ZooManager.Instance.Die();
    }


    private void OnMouseDown()
    {
        if (Sleep == false)
        {
            ZooManager.Instance.FeedManager(thisAnimal);
        }
    }

    public void ModifyHunger(float actualHungerM, float actualHungerF, float actualHungerV)
    {
        ActualHunger += actualHungerM;

        if (ActualHunger >= Hunger)
        {
            ActualHunger = Hunger;
        }
    }

    public void ModifyThirst(float actualThirst)
    {
        ActualThirst += actualThirst;

        if (ActualThirst >= Thirst)
        {
            ActualThirst = Thirst;
        }
    }


    //  SET/GET
    public void SetAge(int newAge)
    {
        Age = newAge;
    }
    public int GetAge()
    {
        return Age;
    }
    public void SetHunger(float newHunger)
    {
        ActualHunger = newHunger;
    }
    public float GetHunger()
    {
        return ActualHunger;
    }
    public void SetThirst(float newThirst)
    {
        ActualThirst = newThirst;
    }
    public float GetThirst()
    {
        return ActualThirst;
    }
    public void SetTiredness(float newTiredness)
    {
        ActualTiredness = newTiredness;
    }
    public float GetTiredness()
    {
        return Tiredness;
    }
    public void SetAgeTime(float newAgeTime)
    {
        AgeTime = newAgeTime;
    }
    public float GetAgeTime()
    {
        return AgeTime;
    }
}

enum TypeOfFoodEat
{
    Meat,
    Fish,
    Vegetable,
    omnivore
}