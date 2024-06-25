using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LocationMenuManager : MonoBehaviour
{
    public string NextLocationName = "DefultLocation";
    public GameObject ScrollViewContent;
    public GameObject ScrollViewContainer;
    public int Level;

    private void Start()
    {
        if (GlobalData.Instance.IsWin) return;
        YandexGame.FullscreenShow();
    }
    public void EnterInLocation()
    {
        var dataPath = Application.dataPath + "/Resources/Locations";
        var LocChooser = ScrollViewContainer.transform.parent.parent.gameObject;
        if (LocChooser.activeSelf)
        {
            ScrollViewContainer.SetActive(false);
            var i = 0;
            while (LocChooser.transform.childCount > 0)
            {
                Destroy(ScrollViewContainer.transform.GetChild(0).gameObject);
                i++;
                if (i > 100)
                {
                    Debug.Log(i);
                    break;
                }
            }
            LocChooser.SetActive(false);
            return;
        }
        LocChooser.SetActive(true);
        
        foreach (var item in Directory.GetFiles(dataPath))
        {
            if (!item.Contains(".meta"))
            {
                var contentItem = Instantiate(ScrollViewContent, ScrollViewContainer.transform);
                var locationTypedName = item.Replace(dataPath + @"\","");
                var locationName = locationTypedName.Replace(".json","");
                var location = LoadLocation(locationName);
                contentItem.GetComponent<LocationButtonController>().Location = location;
            }
        };
        
    }

    public Location LoadLocation(string locationName)
    {
        var dataPath = Application.dataPath + "/Resources/Locations";
        var locData = JsonUtility.FromJson<LocationData>
            (File.ReadAllText($"{dataPath}/{locationName}.json"));
        var location = new Location(locData);
        var sprite = Resources.Load<Texture2D>($"Sprites/Locations/{NextLocationName}");
        location.Background = sprite;
        return location;
    }
}
