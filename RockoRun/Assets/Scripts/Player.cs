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
        /*if (isGrounded)
        {
            rb.velocity = new Vector2(speed, 0);

        }*/
    }
    public void Jump ()
    {
        if (isGrounded)
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
            Destroy(collision.gameObject);
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
}




    
  
