using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationInfo : MonoBehaviour
{
    public string name { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public TextMeshProUGUI Power;
    public GameObject body { get; set; }
    public string text { get; set; }
    void Update()
    {
        Power.text = text; //gan text len UI
    }
} 
