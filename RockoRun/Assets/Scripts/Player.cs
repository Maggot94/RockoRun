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
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }
    private void Update()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump ()
    {
        Debug.Log("hwdqudhw");
        //rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        rb.velocity = new Vector2(0, jumpForce);
    }
}




    
  
