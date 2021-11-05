using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlock : MonoBehaviour
{

    public Transform EndPoint;
    public List <SpawnObstaculos> SO;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacles()
    {
        foreach (SpawnObstaculos s in SO)
        {
            s.Spawn();
        }
    }

    public void DespawnRemainingObstacles()
    {
        foreach (SpawnObstaculos s in SO)
        {
            s.deSpawn();
        }
    }

}
