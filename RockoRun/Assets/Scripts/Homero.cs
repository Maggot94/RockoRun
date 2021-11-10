using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homero : MonoBehaviour
{
    [SerializeField] private Transform EntrancePoint;
    [SerializeField] private Transform HidePoint;
    [SerializeField] private float time;
    private bool visible;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Exit()
    {
        visible = false;
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            gameObject.transform.position = Vector2.Lerp(EntrancePoint.position, HidePoint.position, t);
            yield return null;
        }
    }
    public IEnumerator Entrance()
    {
        visible = true;
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            gameObject.transform.position = Vector2.Lerp(HidePoint.position, EntrancePoint.position, t);
            yield return null;
        }
    }

    public void EntranceExit(bool state)
    {
        if (state && !visible)
        {
            StartCoroutine(Entrance());
        } else
        {
            StartCoroutine(Exit());
        }
        
    }
}
