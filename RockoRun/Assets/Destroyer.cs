using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject Pool;

    private void Awake()
    {
        Pool = GameObject.FindGameObjectWithTag("ObstaclePool");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Letal") || collision.gameObject.CompareTag("Tropiezo"))
        {
            collision.gameObject.transform.position = Pool.gameObject.transform.position;
        }
    }
}
