using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelPartList;
    [SerializeField] private Transform poolBlock;
    [SerializeField] private Transform firstEndPosition;

     
    private GameObject[] ActiveBlocks = new GameObject[3];
    private GameObject objectToSpawn;
 
    // Start is called before the first frame update
    void Start()
    {
        //ActiveBlocks[1] = firstEndPosition;
        GameObject temp;
        foreach(GameObject g in levelPartList)
        {
            for(int i = 0; i < 5; i++)
            {
                temp = Instantiate(g,poolBlock.transform);
                temp.GetComponent<LevelBlock>().EndPoint.gameObject.GetComponent<EndPoint>().LM = gameObject.GetComponent<LevelManager>();
                
            }
        }

        objectToSpawn = poolBlock.transform.GetChild(Random.Range(0, poolBlock.transform.childCount)).gameObject;
        objectToSpawn.transform.position = firstEndPosition.position;
        ActiveBlocks[2] = objectToSpawn;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabNextBlock()
    {
        do
        {
            objectToSpawn = poolBlock.transform.GetChild(Random.Range(0, poolBlock.transform.childCount)).gameObject;
        } while (objectToSpawn.transform.position != poolBlock.transform.position);

        objectToSpawn.transform.position = ActiveBlocks[2].GetComponent<LevelBlock>().EndPoint.position; 

            if (ActiveBlocks[0] != null)
            {
                ActiveBlocks[0].transform.position = poolBlock.transform.position;
            }
        ActiveBlocks[0] = ActiveBlocks[1];
        ActiveBlocks[1] = ActiveBlocks[2];
        ActiveBlocks[2] = objectToSpawn;

    }
}
