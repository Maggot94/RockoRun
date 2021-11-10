using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cientifico : MonoBehaviour
{
    [SerializeField] private Transform EntrancePoint;
    [SerializeField] private Transform LowestPoint;
    [SerializeField] private Transform HidingPosition;
    [SerializeField] private float time;
    [SerializeField] private float timeMove;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform SpawnProjectile;



    void Start()
    {
        StartCoroutine(Spawntime());
    }
    IEnumerator Action()
    {
        for(float t = 0; t < 1; t+= Time.deltaTime / time)
        {
            gameObject.transform.position =  Vector2.Lerp(HidingPosition.position, EntrancePoint.position,t);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);

        Transform Target;
        Transform Origin;
        for(int i = 0; i < 3; i++)
        {
            StartCoroutine(Shot(Random.Range(0, timeMove * 4f)));
        }

        for ( int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
            {
                Target = LowestPoint.transform;
                Origin = EntrancePoint.transform;

            } else
            {
                Target = EntrancePoint.transform;
                Origin = LowestPoint.transform;
            }
            for (float t = 0; t < 1; t += Time.deltaTime / timeMove)
            {
                gameObject.transform.position = Vector2.Lerp(Origin.position, Target.position, t);
               
                yield return null;
            }

        }
        yield return new WaitForSeconds(0.5f);

        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            gameObject.transform.position = Vector2.Lerp(EntrancePoint.position, HidingPosition.position, t);
            yield return null;
        }

        StartCoroutine(Spawntime());


    }

    IEnumerator Spawntime ()
    {
        yield return new WaitForSeconds(40f);
        StartCoroutine(Action());

    }
    
    IEnumerator Shot (float TiempoParaDisparar)
    {
        yield return new WaitForSeconds(TiempoParaDisparar);
        Shot();


    }

    public void Shot()
    {
        Instantiate(Projectile, SpawnProjectile.position, SpawnProjectile.rotation);
    }


}
