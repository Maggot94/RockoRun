using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{

    
    private GameObject Pool;
    // Start is called before the first frame update
    private void Awake()
    {
        Pool = GameObject.FindGameObjectWithTag("ObstaclePool");
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        GameObject objectToSpawn;
        do
        {
            objectToSpawn = Pool.transform.GetChild(Random.Range(0, Pool.transform.childCount)).gameObject;
            Debug.Log(Pool.transform.position + " == " + objectToSpawn.transform.position);

        } while (objectToSpawn.transform.position != Pool.transform.position);

            objectToSpawn.transform.position = gameObject.transform.position;
    }
}
