using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*
    public GameObject Enemy; // El objeto que deseas instanciar
    public Transform spawn; // La posici�n de aparici�n inicial
    public float spawnInterval = 15.0f; // Intervalo de aparici�n en segundos
    public int maxSpawnCount = 5; // M�ximo n�mero de objetos a instanciar
    private int currentSpawnCount = 0; // Contador de objetos instanciados
    private float timer = 0; // Temporizador para controlar las apariciones
    void Update()
    {
        timer += Time.deltaTime;

        if (currentSpawnCount < maxSpawnCount && timer >= spawnInterval)
        {
            Instantiate(Enemy, spawn.position, Quaternion.identity);
            currentSpawnCount++;
            timer = 0;
        }
    }
    */


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet") 
        {

            KillCounter KC = FindFirstObjectByType<KillCounter>();
            KC.IncrementCounter();
            Destroy(other.gameObject);
            Destroy(gameObject);

            
        }

        
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            
            





                
        }



        



    }
}
