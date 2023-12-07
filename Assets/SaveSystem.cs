using UnityEngine;
using System.IO;
using static UnityEditor.Progress;
using System.Net.Cache;
using Unity.VisualScripting;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public PlayerInfo player;
    void Start()
    {
        instance = this;
        Load();

    }

    public void Load()
    {
        Debug.Log(Application.persistentDataPath);

        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            player = JsonUtility.FromJson<PlayerInfo>(json);
            ZooManager.Instance.money = player.money;
            ZooManager.Instance.NbAnnimal = player.NbAnnimal;
            foreach (SaveAnnimal i in player.inventory)
            {
                Animal AnimalRespawn = new Animal();

                Vector3 AnimalPos = new Vector3(i.x, i.y, i.z);

                AnimalRespawn.Name = i.Name;

                AnimalRespawn.SetAge(i.Age);
                AnimalRespawn.SetHunger(i.ActualHunger) ;
                AnimalRespawn.SetThirst(i.ActualThirst) ;
                AnimalRespawn.SetTiredness(i.ActualTiredness) ;
                AnimalRespawn.SetAgeTime(i.AgeTime) ;
                AnimalRespawn.FirstTime = i.FirstTime;

                GameObject AnimalSpawn = Instantiate(Resources.Load<GameObject>("Prefab/" + i.namePrefab.Replace("(Clone)", "")));
                AnimalSpawn.transform.position = AnimalPos;
            }
        }

    }

    public void Save()
    {
        player.money = ZooManager.Instance.money;
        player.NbAnnimal = ZooManager.Instance.NbAnnimal;

        GameObject[] AllAnimal;
        AllAnimal = GameObject.FindGameObjectsWithTag("Annimal");
        player.inventory.Clear();
        foreach (GameObject AnimalInZoo in AllAnimal)
        {
            Vector3 AnimalPosition = AnimalInZoo.transform.position;
            player.inventory.Add(new SaveAnnimal()
            {
                namePrefab = AnimalInZoo.name,
                Name = AnimalInZoo.GetComponent<Animal>().Name,
                FirstTime = AnimalInZoo.GetComponent<Animal>().FirstTime,
                Age = AnimalInZoo.GetComponent<Animal>().GetAge(),
                ActualHunger = AnimalInZoo.GetComponent<Animal>().GetHunger(),
                ActualThirst = AnimalInZoo.GetComponent<Animal>().GetThirst(),
                ActualTiredness = AnimalInZoo.GetComponent<Animal>().GetTiredness(),
                AgeTime = AnimalInZoo.GetComponent<Animal>().GetAgeTime(),
                x = AnimalPosition.x,
                y = AnimalPosition.y,
                z = AnimalPosition.z,
            });
        }
        Debug.Log(Application.persistentDataPath + "/data.save");
        string json = JsonUtility.ToJson(player);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }
}

