using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Location
{
    public string Name;
    public string Description;
    public int Level;
    public Stack<EnemyData> Enemies = new();
    public Texture2D Background;

    public delegate void LocationClearedHandle();
    public event LocationClearedHandle OnLocationCleared;

    public Location(LocationData locationData)
    {
        LoadData(locationData);
    }

    public EnemyData GetNextEnemy()
    {
        if (Enemies.Count >= 0) return Enemies.Pop();
        else
        {
            OnLocationCleared?.Invoke();
            return null;
        }
    }

    public void LoadData(LocationData locationData)
    {
        Name = locationData.Name;
        Description = locationData.Description;
        Level = locationData.Level;
        var dataPath = Application.dataPath + "/Resources/Enemies";
        foreach (string enemyName in locationData.EnemiesFilesNames)
        {
            var enemyData = JsonUtility.FromJson<EnemyData>(File.ReadAllText(dataPath + $"/{enemyName}.json"));
            var sprite = Resources.Load<Texture2D>($"Sprites/Enemies/{enemyName}");
            enemyData.Sprite = sprite;
            enemyData.Level = Level;
            Enemies.Push(enemyData);
        }
        Debug.Log(Enemies);
    }

    public void SaveData()
    {
        var locationData = new LocationData();
        locationData.Name = Name;
        locationData.Description = Description;
        locationData.EnemiesFilesNames.Add("Slime");
        locationData.EnemiesFilesNames.Add("Slime");
        locationData.EnemiesFilesNames.Add("Slime");
        locationData.EnemiesFilesNames.Add("Slime");

        var dataPath = Application.dataPath + "/Resources/Locations";
        File.WriteAllText(dataPath + $"/Location.json", JsonUtility.ToJson(locationData));
    }
}
