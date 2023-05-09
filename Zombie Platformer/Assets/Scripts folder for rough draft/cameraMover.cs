using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    public GameObject player;
    public float myFloat = 0.03f;
    private float playerYPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, playerYPosition(), -1); ;
  
    }
    private float playerYPosition()
    {
        playerYPos = player.transform.position.y;
        return playerYPos;
    }
}
