using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocationData
{
    public string Name;
    public string Description;
    public int Level;
    public List<String> EnemiesFilesNames = new();
}
