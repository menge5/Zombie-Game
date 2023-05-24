using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    PlayerManager TheManager;
    public Text healthText; 
    // Start is called before the first frame update
    void Start()
    {
        TheManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = TheManager.health.ToString();
    }
}
