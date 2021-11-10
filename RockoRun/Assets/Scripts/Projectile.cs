using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
        StartCoroutine(DestroyMe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyMe ()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Health--;
            StopCoroutine(DestroyMe());
            Destroy(gameObject);
        }
    }
}
