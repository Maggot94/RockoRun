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
    [SerializeField]
    private float slideForce;

    public bool isGrounded;

    public int Coins;

    public int Health = 2;

    public bool invencible;

    private bool Sliding;

    public bool magnet;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        isGrounded = false;
        StartCoroutine(speedUpPlayer());
       
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
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
        if (collision.CompareTag("Tropiezo") && !invencible)
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            Health--;
            StartCoroutine(RestoreHealth());
        }
        if (collision.CompareTag("Letal") && !invencible)
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            Health = 0;
        }
        if (collision.CompareTag("Slide") && !invencible)
        {
            if (!Sliding)
            {
                collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
                Health--;
                StartCoroutine(RestoreHealth());
            }
        }
        if (collision.CompareTag("Boost"))
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            invencible = true;
            rb.velocity = new Vector2(speed + 10, 0);
            StartCoroutine(endBoost());
        }

        if (collision.CompareTag("Iman"))
        {
            collision.GetComponent<Obstacle>().currentSpawner.deSpawn();
            magnet = true;
            StartCoroutine(endMagnet());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if (!invencible)
            {
               rb.velocity = new Vector2(speed, 0);
            } else
            {
              rb.velocity = new Vector2(speed + 10, 0);
            }
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

    public void Slide ()
    {
       
       if(!Sliding)
        {
            Sliding = true;
            rb.velocity = new Vector2(rb.velocity.x + slideForce, 0);
            StartCoroutine(endSlide());

        }
    }
    IEnumerator endSlide ()
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(speed, 0);
        Sliding = false;

    }
    IEnumerator endBoost()
    {
        yield return new WaitForSeconds(3f);
        rb.velocity = new Vector2(speed, 0);
        invencible = false;

    }
    IEnumerator endMagnet()
    {
        yield return new WaitForSeconds(8f);
        magnet = false;

    }
    IEnumerator speedUpPlayer()
    {
        yield return new WaitForSeconds(20f);
        speed = speed + 3;
        rb.velocity = new Vector2(speed, 0);
        StartCoroutine(speedUpPlayer());

    }
}




    
  
