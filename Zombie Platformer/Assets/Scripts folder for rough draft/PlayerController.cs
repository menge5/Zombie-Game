using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 5f;
    private float playerThrust = 200f;
    public GameObject projectile;
    Rigidbody2D playerRB;
    private bool Jump = false;
    public bool look = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.Rotate(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {   
            transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);

        }
        
        if (Input.GetKeyDown(KeyCode.W) && Jump == false)
        {
            playerRB.AddForce(transform.up * playerThrust );
            Jump = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0f, 0f, 0f);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            Jump = false;
        }
    }
}
