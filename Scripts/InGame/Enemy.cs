
using UnityEngine;

public class Enemy : GamePawn
{
    public string Name;
    public string Desc;
    public Texture2D Sprite;

    public override void SetFromData(GamePawnData data)
    {
        if (data == null) return;

        var enemyData = (EnemyData)data;
        Name = enemyData.Name;
        Sprite = enemyData.Sprite;
        Desc = enemyData.Description;
        SetBaseData(enemyData);
        //xApplyLevel(enemyData.Level);
        Hp = MaxHp;
        Debug.Log($"dataMaxHp={enemyData.MaxHp}, enemyHp={Hp}, enemyMaxHp={MaxHp}");
    }

    public void ApplyLevel(int level)
    {
        MaxHp *= 0.4f * level;
        Hp = MaxHp;
        Dmg *= 0.4f * level;
    }
}
