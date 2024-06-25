using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalData
{
    private static GlobalData _instance;
    private GlobalData()  {}
    public static GlobalData Instance {get {return _instance ??= new GlobalData();}}

    public int Level;
    public bool IsWin = true;
    public Location CurrentLocation;
}
