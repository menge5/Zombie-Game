using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectile2;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerController.facingRight)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !playerController.facingRight)
        {
            Instantiate(projectile2, transform.position, projectile2.transform.rotation);
        }

    }
}
