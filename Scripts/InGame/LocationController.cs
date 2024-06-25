using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationController : MonoBehaviour
{
    public Location location;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescText;
    public RawImage Background;
    void Start()
    {
        location = GlobalData.Instance.CurrentLocation;
        NameText.text = location.Name;
        DescText.text = location.Description;
        Background.texture = location.Background;
        if (location.Background == null) Debug.Log("sda");
    }
}
