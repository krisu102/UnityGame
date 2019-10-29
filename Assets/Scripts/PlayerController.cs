using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float speed;
    private float moveInput;
    private bool Grounded;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;

	// Use this for initialization
	void Start () {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        //checking if player is on ground
        Grounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);

        PlayerJump();
        PlayerMove();


    }

    //flip player
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //combat with enemy

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemy enemy = collision.collider.GetComponent<enemy>();
        if(enemy != null)
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 0.9)
                {
                    enemy.Hurt();
                }
                else
                {
                    Hurt();
                }
            }

        }
    }

    void Hurt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlayerJump()
    {
        //Player jumping
        if (Grounded == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && Grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void PlayerMove()
    {
        //player moving
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
}
