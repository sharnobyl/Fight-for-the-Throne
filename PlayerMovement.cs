using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isGrounded = true;
    public bool facingRight = true;
    public int jumpCounter = 0;
    public int playerSpeed = 10;
    public int jumpPower = 1200;
    private float moveHor;
    public Rigidbody2D rb;
    public Animator anim;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        PlayerMove();
    }

    void PlayerMove()
    {
        // Controls

        moveHor = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }
        
        // Animation
        if (moveHor != 0) {
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }
        if (moveHor < 0.0f && facingRight == true) {
            FlipPlayer();
        }
        else if (moveHor > 0.0f && facingRight == false) {
            FlipPlayer();
        }
        // Player Direction
        // Physics
        rb.velocity = new Vector2(moveHor * playerSpeed, rb.velocity.y);
    }
    void Jump()
    {
        jumpCounter++;
        isGrounded = false;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
    }
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"){
            isGrounded = true;
        }
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
