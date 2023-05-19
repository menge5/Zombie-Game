using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerManager : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectile2;
    PlayerController playerController;
    public Transform shootLoc;
    public float health = 10;
    public bool betterGun = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(betterGun == false)
        {
           if (Input.GetKeyDown(KeyCode.Space) && playerController.facingRight)
           {
                Instantiate(projectile, shootLoc.position, Quaternion.identity);

           }
          if (Input.GetKeyDown(KeyCode.Space) && !playerController.facingRight)
          {
              Instantiate(projectile2, shootLoc.position, Quaternion.identity);
          }
        }
        if(betterGun == true )
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerController.facingRight)
            {
                Instantiate(projectile, shootLoc.position, Quaternion.identity);
                timer += 1;
                if (timer == 2 && playerController.facingRight)
                {
                    Instantiate(projectile, shootLoc.position, Quaternion.identity);
                    timer = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && !playerController.facingRight)
            {
                Instantiate(projectile2, shootLoc.position, Quaternion.identity);
                timer += 1;
                if (timer == 2 && !playerController.facingRight)
                {
                    Instantiate(projectile2, shootLoc.position, Quaternion.identity);
                    timer = 0;
                }
            }

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            health--;
        }
        if(collision.gameObject.CompareTag("Power Up"))
        {
            betterGun = true;
            Debug.Log("powerUp");
        }
    }
}
