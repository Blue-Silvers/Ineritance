using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZooManager : MonoBehaviour
{
    public static ZooManager Instance;

    [SerializeField] GameObject ShopM, NameUi;
    public int money = 100;
    [SerializeField] float Money = 100;
    [SerializeField] Transform landSpawn, waterSpawn, skySpawn;
    public int NbAnnimal = 0;

    public TextMeshProUGUI MoneyTxt, NbAnnimalTxt;
    public bool WindowOpen = false;

    public TextMeshProUGUI DieingTxt;


    private void Start()
    {
        DieingTxt.text = " ";
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CloseShop();
        }

        Money += Time.deltaTime + ( NbAnnimal / 200f);
        money = (int)Money;
        MoneyTxt.text = money.ToString();
        NbAnnimalTxt.text = "Nomber of annimals : " + NbAnnimal.ToString();
        FeedShop.instance.YourMoney(money);
    }

    public void SetMoney(int newMoney)
    {
        Money = newMoney;
    }

    public void OpenShop()
    {
        if (WindowOpen == false)
        {
            ShopM.SetActive(true);
            WindowOpen = true;
        }
        else
        {
            CloseShop();
        }
    }

    public void CloseShop() 
    {
        ShopM.SetActive(false);
        WindowOpen = false;
    }

    public void Buy(GameObject animal)
    {
        if (Money >= animal.GetComponent<Animal>().price)
        {
            int AnimalSpawn = animal.GetComponent<Animal>().Spawnpoint;
            if (AnimalSpawn == 1) 
            {
                animal = Instantiate(animal, landSpawn.position, landSpawn.rotation);
            }
            else if (AnimalSpawn == 3)
            {
                animal = Instantiate(animal, waterSpawn.position, waterSpawn.rotation);
            }
            else
            {
                animal = Instantiate(animal, skySpawn.position, skySpawn.rotation);
            }

            NbAnnimal++;
            Money = Money - animal.GetComponent<Animal>().price;
            RenamePage(animal.GetComponent<Animal>());
        }
    }

    public void RenamePage(Animal animal)
    {
        NameUi.SetActive(true);
        ChooseName.instance.SetupAnimal(animal);
        //WindowsOpen = false;
        ShopM.SetActive(false);
    }

    public void Die()
    {
        NbAnnimal--;
    }

    public void DieAge(string Name)
    {
        DieingTxt.text = Name + " died of old age.";
    }

    public void DieHunger(string Name)
    {
        DieingTxt.text = Name + " died starving...";
    }

    public void DieThirst(string Name)
    {
        DieingTxt.text = Name + " died of dehydration...";
    }


    public void FeedManager(GameObject animalF)
    {
        FeedShopOpen(animalF.GetComponent<Animal>());
    }

    public void FeedShopOpen(Animal animalF)
    {
        FeedShop.instance.feedShop(animalF);
    }

    public void NewMoney(float cost)
    {
        Money -= cost;
    }
}
