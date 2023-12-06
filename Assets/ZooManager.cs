using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZooManager : MonoBehaviour
{
    [SerializeField] GameObject ShopM, Chimpanzee, Panda, Carp, Piranha, Kingfisher, Vulture;
    [SerializeField] int money = 100;
    [SerializeField] float Money = 100;
    [SerializeField] Transform landSpawn, waterSpawn, skySpawn;
    [SerializeField] int NbAnnimal = 0;

    public TextMeshProUGUI MoneyTxt, NbAnnimalTxt;
    public bool WindowOpen = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CloseShop();
        }

        Money += Time.deltaTime + NbAnnimal * 10;
        money = (int)Money;
        MoneyTxt.text = money.ToString();
        NbAnnimalTxt.text = "Nomber of annimals : " + NbAnnimal.ToString();
    }


    public void OpenShop()
    {
        if (WindowOpen == true)
        {
            ShopM.SetActive(false);
            WindowOpen = false;
        }
        else
        {
            CloseShop();
        }
    }

    public void CloseShop() 
    {
        ShopM.SetActive(true);
        WindowOpen = true;
    }

    public void BuyChimpanzee()
    {
        if(Money>= 100)
        {
            Instantiate(Chimpanzee, landSpawn.position, landSpawn.rotation);
            NbAnnimal++;
            Money = Money - 100;
        }
    }

    public void BuyPanda()
    {
        if (Money >= 750)
        {
            Instantiate(Panda, landSpawn.position, landSpawn.rotation);
            NbAnnimal++;
            Money = Money - 750;
        }
    }
    public void BuyCarp()
    {
        if (Money >= 200)
        {
            Instantiate(Carp, waterSpawn.position, waterSpawn.rotation);
            NbAnnimal++;
            Money = Money - 200;
        }
    }
    public void BuyPiranha()
    {
        if (Money >= 350)
        {
            Instantiate(Piranha, waterSpawn.position, waterSpawn.rotation);
            NbAnnimal++;
            Money = Money - 350;
        }
    }
    public void BuyKingfisher()
    {
        if (Money >= 500)
        {
            Instantiate(Kingfisher, skySpawn.position, skySpawn.rotation);
            NbAnnimal++;
            Money = Money - 500;
        }
    }
    public void BuyVulture()
    {
        if (Money >= 1000)
        {
            Instantiate(Vulture, skySpawn.position, skySpawn.rotation);
            NbAnnimal++;
            Money = Money - 1000;
        }
    }

}
