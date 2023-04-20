using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilescript2 : MonoBehaviour
{
    public GameObject projectile;
    private float moveSpeed = 40f;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(projectile);

    }
}
