using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public int bossHealth = 10;
    public float attackRange = 13f;
    public float speed = 5;
    public float Timer;
    public float coolDown;

    Transform player;

    Transform shotLocation;


    chaseBoss chaseBoss;

    PlayerManager playerManager;

    public bool isFlipped = false;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;

    public Rigidbody2D rb;

    public GameObject projectile;

    public GameObject projectile2;
   
    public GameObject bossPerson;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth < 7 && bossHealth > 3)
        {
            speed = 2f;
            attackRange = 6f;
            phase2 = true;
           
        }
        else if(bossHealth < 3 && bossHealth > 1)
        {
            phase2 = false;
            speed = 1f;
            attackRange = 8f;
            phase3 = true;
            
           
        }
        else if(bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
            Destroy(bossPerson);
        }


        Timer = Time.deltaTime;
    }

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;

        if(transform.position.x > player.position.x  && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            playerManager.TakeDamage();
        }
        if(collision.gameObject.tag == "Projectile")
        {
            bossHealth--;
        }
    }
    public void projectileShoot()
    {
        if(Timer > coolDown)
        {
            if (phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                Timer = 0;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                Timer = 0;
            }
            
        }
    }
}
