using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    public bool isGrounded;

    public int Coins;

    public int Health = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        isGrounded = false;
       
    }
    private void Update()
    {
        
        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Health <= 0)
        {
            StopAllCoroutines();
            rb.velocity = new Vector2(0, 0);
        }
        /*if (isGrounded)
        {
            rb.velocity = new Vector2(speed, 0);

        }*/
    }
    public void Jump ()
    {
        if (isGrounded && Health > 0)
        { 
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        //rb.velocity = new Vector2(0, jumpForce);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            Coins++;

        }
        if (collision.CompareTag("Tropiezo"))
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            Health--;
            StartCoroutine(RestoreHealth());

        }
        if (collision.CompareTag("Letal"))
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            Health = 0;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.velocity = new Vector2(speed, 0);
        }  
    }
 

    public Vector3 GetPosition()
    {
        Vector3 position;
        position = rb.transform.position;

        return position;
    }

    IEnumerator RestoreHealth()
    {
        yield return new WaitForSeconds(6f);
        Health = 2;
    }
 
}




    
  
