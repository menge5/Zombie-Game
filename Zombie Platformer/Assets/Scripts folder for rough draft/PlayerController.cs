using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveDirection;
    private float jumpForce = 5f;
    private float checkRadius = .5f;

    public GameObject myPlayer;

    public Transform ceilingCheck;
    public Transform groundCheck;

    public LayerMask groundObject;

    private Rigidbody2D rb;

    private bool isJumping = false;
    public bool facingRight = true;
    private bool isGrounded;

    private int jumpCount;
    private int jumpMax = 2;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        jumpCount = jumpMax;
    }
    // Update is called once per frame
    void Update()
    {
        ProcessingInputs();

        Animate();



    }
    private void FixedUpdate()
    {
        //Im at at the time 14.03 on my youtube video 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);
        if (isGrounded)
        {
            jumpCount = jumpMax;
        }


        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {

            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipCharacter();

        }
        else if (moveDirection < 0 && facingRight)
        {
            flipCharacter();
        }
    }

    private void ProcessingInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;

        }
    }

    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    IEnumerator PowerUpSpeed()
    {
        moveSpeed = 9f;
        yield return new WaitForSeconds(5);
        moveSpeed = 5f;
    }

    public void SpeedPowerUp()
    {
        StartCoroutine(PowerUpSpeed());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = col.transform;
        }
        if (col.gameObject.CompareTag("Power Up"))
        {
            moveSpeed = 10f;
        }
        if (col.gameObject.CompareTag("spikes"))
        {
            Destroy(myPlayer);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
