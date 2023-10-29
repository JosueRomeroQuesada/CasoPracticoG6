using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed = 15.0f;

    [SerializeField]
    float lifeTime = 3.0f;

    Rigidbody2D rb;

    



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

     void Start()
     {
        Destroy(gameObject , lifeTime);
        
     }

    void FixedUpdate()
    {
        rb.velocity= transform.up*speed;
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy (gameObject);
        
    }


}
