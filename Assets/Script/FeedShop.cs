using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedShop : MonoBehaviour
{
    private Animal current;

    [SerializeField] GameObject FoodShopUI, NeedFood, NeedWater;
    public TextMeshProUGUI NameOnShop;

    int yourMoney;

    public static FeedShop instance;

    public float Food, Water;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CloseFeedShoop();
        }
    }

    public void YourMoney(int ActualMoney)
    {
        yourMoney = ActualMoney;
    }

    public void feedShop(Animal animal)
    {
        FoodShopUI.SetActive(true);
        current = animal;
        NameOnShop.text = animal.Name + " need :";
        if (current.ActualHungerP <= 50)
        {
            NeedFood.SetActive(true);
        }
        else
        {
            NeedFood.SetActive(false);
        }
        if (current.ActualThirstP <= 50)
        {
            NeedWater.SetActive(true);
        }
        else
        {
            NeedWater.SetActive(false);
        }
    }

    public void MeatButton()
    {
        if (yourMoney >= 75)
        {
            Food = 50;
            current.ModifyHunger(Food, 0, 0);
            ZooManager.Instance.NewMoney(75f);
            Invoke("Newstate", 0.1f);
        }
    }
    public void VegetalButton()
    {
        if (yourMoney >= 50)
        {
            Food = 50;
            current.ModifyHunger(0, 0, Food);
            ZooManager.Instance.NewMoney(50f);
            Invoke("Newstate", 0.1f);
        }
    }
    public void FishButton()
    {
        if (yourMoney >= 25)
        {
            Food = 50;
            current.ModifyHunger(0, Food, 0);
            ZooManager.Instance.NewMoney(25f);
            Invoke("Newstate", 0.1f);
        }
    }
    public void WaterButton()
    {
        if (yourMoney >= 10)
        {
            Water = 50;
            current.ModifyThirst(Water);
            ZooManager.Instance.NewMoney(10f);
            Invoke("Newstate", 0.1f);
        }
    }

    public void CloseFeedShoop()
    {
        FoodShopUI.SetActive(false);
    }

    private void Newstate()
    {
        if (current.ActualHungerP <= 50)
        {
            NeedFood.SetActive(true);
        }
        else
        {
            NeedFood.SetActive(false);
        }
        if (current.ActualThirstP <= 50)
        {
            NeedWater.SetActive(true);
        }
        else
        {
            NeedWater.SetActive(false);
        }
    }
}
