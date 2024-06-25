using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class EnemyData : GamePawnData
{
    public string Name;
    public string Description;

    [DoNotSerialize]
    public int Level;

    [DoNotSerialize]
    public Texture2D Sprite;
}
