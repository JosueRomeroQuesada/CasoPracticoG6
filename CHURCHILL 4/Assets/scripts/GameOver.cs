using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameText;


    void Awake()
    {
        nameText.text = StateManager.Instance.getKill().ToString();
        
    }

}
