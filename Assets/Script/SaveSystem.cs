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
                //GameObject AnimalRespawn = new GameObject();

                Vector3 AnimalPos = new Vector3(i.x, i.y, i.z);

                GameObject AnimalRespawn = Instantiate(Resources.Load<GameObject>("Prefab" + i.namePrefab.Replace("(Clone)", "").Trim()));

                AnimalRespawn.AddComponent<Animal>().Name = i.Name;
                AnimalRespawn.AddComponent<Animal>().SetAge(i.Age);
                AnimalRespawn.AddComponent<Animal>().SetHunger(i.ActualHunger) ;
                AnimalRespawn.AddComponent<Animal>().SetThirst(i.ActualThirst) ;
                AnimalRespawn.AddComponent<Animal>().SetTiredness(i.ActualTiredness) ;
                AnimalRespawn.AddComponent<Animal>().SetAgeTime(i.AgeTime) ;
                AnimalRespawn.AddComponent<Animal>().FirstTime = i.FirstTime;

                AnimalRespawn.transform.position = AnimalPos;
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

