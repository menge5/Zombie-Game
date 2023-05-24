using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    public GameObject player;
    public float myFloat = 0.03f;
    private float playerYPos;
    private float playerXPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(playerXPosition()+ 10f, playerYPosition()+3.38f, -1); 

    }
    private float playerYPosition()
    {
        playerYPos = player.transform.position.y;
        return playerYPos;
    }
    private float playerXPosition()
    {
        playerXPos = player.transform.position.x;
        return playerXPos;
    }
}
