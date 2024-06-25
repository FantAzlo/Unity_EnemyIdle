using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationButtonController : MonoBehaviour
{
    public int Level;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;

    private Location _location;
    public Location Location
    {
        get { return _location; }
        set 
        { 
            _location = value;
            NameText.text = value.Name;
            DescriptionText.text = value.Description;
        }
    }

    public void OnEnterButton()
    {
        GlobalData.Instance.Level = Level;
        GlobalData.Instance.CurrentLocation = Location;
        SceneManager.LoadScene("LocationScene");
    }
}
