
using System.IO;
using System.Xml;
using UnityEngine;

public class Player: GamePawn
{
    public int Location;
    public int Level = 1;

    public int Exp = 3;
    public override void SetFromData(GamePawnData data)
    {
        if (data == null) return;

        var playerData = (PlayerData) data;
        Level = playerData.Level;
        Exp = playerData.Exp;
        SetBaseData(data);
        Hp = MaxHp;
    }

    public void SaveData()
    {
        var data = new PlayerData();
        data.Level = Level;
        data.Exp = Exp;
        data.Dmg = Dmg;
        data.MaxHp = MaxHp;
        data.AttackSpeed = AttackSpeed;
        string dataPath = Application.dataPath + "/Resources/Player/Player.json";
        File.WriteAllText(dataPath,JsonUtility.ToJson(data));
    }

    public void LoadData()
    {
        string dataPath = Application.dataPath + "/Resources/Player/Player.json";
        PlayerData data;
        try
        {
            data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(dataPath));

        }
        catch 
        { 
            SaveData();
            data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(dataPath));
        }
        SetFromData(data);
    }
}
