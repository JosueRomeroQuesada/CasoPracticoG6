using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabTank;
    private float ramdomX;
    private float ramdomY;
    public float spawnInterval = 15.0f; // Intervalo de aparición en segundos
    private float timer = 0; // Temporizador para controlar las apariciones
   
    void Start()
    {
        CrearTanque();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            CrearTanque();
            timer = 0;
        }

    }
    public void CrearTanque()
    {
        for (int i=0; i< 3; i++) {
            ramdomX = Random.Range(-15f, 15F);
            ramdomY = Random.Range(-10F, 10F);
            GameObject a = Instantiate(prefabTank) as GameObject;
            a.transform.position = new Vector3(ramdomX,ramdomY, 0f);
        }
    }
}
