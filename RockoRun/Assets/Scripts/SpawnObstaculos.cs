using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaculos : MonoBehaviour
{

    
    private GameObject Pool;
    public bool active;
    private GameObject spawnedObstacle;

    [SerializeField] private bool platforms;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!platforms)
        {
            Pool = GameObject.FindGameObjectWithTag("ObstaclePool");
        } else
        {
            Pool = GameObject.FindGameObjectWithTag("PlatformPool");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject objectToSpawn;
       
            do
            {
                objectToSpawn = Pool.transform.GetChild(Random.Range(0, Pool.transform.childCount)).gameObject;

            } while (objectToSpawn.transform.position != Pool.transform.position);     
                objectToSpawn.transform.position = gameObject.transform.position;
           if(!platforms)
            {
               objectToSpawn.transform.GetChild(0).GetComponent<Obstacle>().currentSpawner = gameObject.GetComponent<SpawnObstaculos>();
            }
                spawnedObstacle = objectToSpawn;
                active = true;
             
    }

    public void deSpawn()
    {
        if (active)
        {
            spawnedObstacle.gameObject.transform.position = Pool.gameObject.transform.position;
            if (!platforms)
            {
                spawnedObstacle.transform.GetChild(0).GetComponent<Obstacle>().currentSpawner = null;
            }
            active = false; 
        }
            
    }
}
