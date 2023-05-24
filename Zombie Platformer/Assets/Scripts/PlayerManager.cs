using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private float timer = 5;
    private bool Projectile1 = false;
    public bool floor2 = false;
    private bool Projectile2 = false;

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
        if(betterGun ==true)
        {
           if (Input.GetKeyDown(KeyCode.Space) && playerController.facingRight)
           {
                Instantiate(projectile, shootLoc.position, Quaternion.identity);
               
                timer =- Time.deltaTime;
                Projectile1 = true;
            
           }
          if (Input.GetKeyDown(KeyCode.Space) && !playerController.facingRight)
          {
              Instantiate(projectile2, shootLoc.position, Quaternion.identity);

            timer = -Time.deltaTime;
            Projectile2 = true;

          }
        }

        
          if(timer <= 0)
          {
            timerEnds();
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
        if(collision.gameObject.CompareTag("Floor2"))
        {
            floor2 = true;
            Debug.Log("floor is true");
        }
    }
    private void timerEnds()
    {
        if(Projectile1)
        {
            
            Instantiate(projectile, shootLoc.position, Quaternion.identity);
            timer = 5;
            Projectile1 = false;
        }
        if (Projectile2)
        {
            Instantiate(projectile2, shootLoc.position, Quaternion.identity);
            timer = 5;
            Projectile2 = false;
        }
    }
}
