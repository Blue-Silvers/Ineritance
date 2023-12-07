using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedShop : MonoBehaviour
{
    private Animal current;

    [SerializeField] GameObject FoodShopUI, NeedFood, NeedWater;
    public TextMeshProUGUI NameOnShop;

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

        public void feedShop(Animal animal)
    {
        FoodShopUI.SetActive(true);
        current = animal;
        NameOnShop.text = animal.Name + " need :";
        if (animal.ActualHungerP <= 50)
        {
            NeedFood.SetActive(true);
        }
        else
        {
            NeedFood.SetActive(false);
        }
        if (animal.ActualThirstP <= 50)
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
        Food = 50;
        current.ModifyHunger(Food, 0, 0);
    }
    public void VegetalButton()
    {
        Food = 50;
        current.ModifyHunger(0, 0, Food);
    }
    public void FishButton()
    {
        Food = 50;
        current.ModifyHunger(0, Food, 0);
    }
    public void WaterButton()
    {
        Water = 50;
        current.ModifyThirst(Water);
    }

    public void CloseFeedShoop()
    {
        FoodShopUI.SetActive(false);
    }
}
