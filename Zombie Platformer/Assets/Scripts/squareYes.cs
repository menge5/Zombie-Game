using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareYes : MonoBehaviour
{
    public GameObject zombie;
    public Transform trans;
    PlayerController PC;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()

    { 
          timer += Time.deltaTime; 



        if (timer > 4f)
        {
            Instantiate(zombie, trans.position, Quaternion.identity);
            timer = 0f;
            Debug.Log("yes");
        }

    }

}