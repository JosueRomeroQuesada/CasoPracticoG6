using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillCounter : MonoBehaviour
{
    public int _kill = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _kill++;
            StateManager.Instance.setKill(_kill);
            
        }
    }
}
 
