using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    LayerMask lmWalls;
    [SerializeField]
    float fJumpVelocity = 5;

    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;

    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;

    [SerializeField]
    float fHorizontalAcceleration = 1;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingBasic = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenStopping = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenTurning = 0.5f;

    [SerializeField]
    [Range(0, 1)]
    float fCutJumpHeight = 0.5f;

    public bool facingRight = true;
    public int playerSpeed = 10;
    private float moveHor;
    Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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

        
        Jump();
        
        
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
        float fHorizontalVelocity = rb.velocity.x;
        fHorizontalVelocity += Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
        else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(fHorizontalVelocity))
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
        else
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);

        rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);
    }
    void Jump()
    {
        Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + new Vector2(0, -0.01f);
        Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + new Vector2(-0.02f, 0);
        bool bGrounded = Physics2D.OverlapBox(v2GroundedBoxCheckPosition, v2GroundedBoxCheckScale, 0, lmWalls);

        fGroundedRemember -= Time.deltaTime;
        if (bGrounded) {
            fGroundedRemember = fGroundedRememberTime;
        }

        fJumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump")) {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }

        if (Input.GetButtonUp("Jump")) {
            if (rb.velocity.y > 0) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * fCutJumpHeight);
            }
        }

        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0)) {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, fJumpVelocity);
        }
    }
   
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer) {

            timer += Time.deltaTime;

            rb.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;

     }
}
