using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public GameObject projectile;
    private float moveSpeed = 40f;
    PlayerController playerController;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Projectile"))
        { 

        Destroy(projectile);

        }
    }
    
   
    
}
