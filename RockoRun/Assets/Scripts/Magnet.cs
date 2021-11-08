using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Player p;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin") && p.magnet)
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            p.Coins++;
        }
    }
    private void Update()
    {
        transform.position = p.transform.position;
    }
}
