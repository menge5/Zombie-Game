using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilescript2 : MonoBehaviour
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
        rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);

    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {

            Destroy(projectile);

        }
    }

}
