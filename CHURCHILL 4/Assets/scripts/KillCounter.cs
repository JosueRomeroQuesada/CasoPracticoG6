using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class KillCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI KillCounterText;
    private int _kills;
    void Start()
    {
        _kills = 0;
        UpdateCounter();
    }
    public void IncrementCounter()
    {
        _kills++;
        UpdateCounter();
    }
    void UpdateCounter()
    {
        KillCounterText.text = "Tanques eliminados: " + _kills.ToString();
    }
}
 
