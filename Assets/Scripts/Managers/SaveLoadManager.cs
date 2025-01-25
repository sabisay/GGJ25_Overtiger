using System.IO;
using UnityEngine;

public class PlayerData
{
    public int Health;
    public int Bullet;
    public int Soap;
    public int Water;
}

public class SaveLoadManager : MonoSingleton<SaveLoadManager>
{
    PlayerData playerData;
    string saveFilePath;

    private void Start()
    {
        playerData = new PlayerData();
        playerData.Health = PlayerHealthSystem.Instance.Health;
        playerData.Bullet = PlayerHealthSystem.Instance.GunScript.Bullet;
        playerData.Soap = PlayerHealthSystem.Instance.Soap;
        playerData.Water = PlayerHealthSystem.Instance.Water;

        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
    }

    public void SaveGame()
    {
        string savePlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, savePlayerData);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
        }
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }
}