using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ZooScript : MonoBehaviour
{
    //[SerializeField] GameObject mammals;
    //[SerializeField] protected int NbAnnimals = 0;


    [SerializeField] protected string Name;
    [SerializeField] protected int Age;

    [SerializeField] private TypeOfFoodEat typeOfFood;

    [SerializeField] protected float Hunger, Thirst, Tiredness;
    [SerializeField] protected float ActualHunger = 100, ActualThirst = 100, ActualTiredness = 100;
    [SerializeField] GameObject HungerIcone, ThirstIcone, TirednessIcone;

    [SerializeField] protected bool Sleep;

    protected void Start()
    {
        Tiredness = Random.Range(20, 200);
        ActualHunger = Hunger;
        ActualThirst = Thirst;
        ActualTiredness = Tiredness;
        Sleep = false;
    }

    protected void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(mammals);
            NbAnnimals++;
        }*/


        //need feed
        ActualHunger -= Time.deltaTime;
        if (ActualHunger < 0)
        {
            Destroy(gameObject);
            AnnimalDie();
        }
        else if (ActualHunger < 50) 
        { 
            HungerIcone.SetActive(true);
        }


        //need water
        ActualThirst -= Time.deltaTime;
        if (ActualThirst < 0)
        {
            Destroy(gameObject);
            AnnimalDie() ;
        }
        else if (ActualThirst < 50)
        {
            ThirstIcone.SetActive(true);
        }

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

    protected void SleepTime()
    {
        Tiredness = Random.Range(20, 200);
        ActualTiredness = Tiredness;
        Sleep = false;
        TirednessIcone.SetActive(false);
    }


    /*protected void NewMammals()
    {
        NbAnnimals++;
    }*/

    public void AnnimalDie()
    {
        ZooManager.Instance.Die();
    }

}

enum TypeOfFoodEat
{
    Meat,
    Fish,
    Vegetable,
    omnivore
}