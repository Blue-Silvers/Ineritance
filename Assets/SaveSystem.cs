using UnityEngine;
using System.IO;
using static UnityEditor.Progress;

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
        }

    }

    public void Save()
    {
        player.money = ZooManager.Instance.money;
        player.NbAnnimal = ZooManager.Instance.NbAnnimal;


        Debug.Log(Application.persistentDataPath + "/data.save");
        string json = JsonUtility.ToJson(player);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }
}

