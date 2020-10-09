using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    //[SerializeField]
    //LayerMask lmWalls;
    [SerializeField]
    float fJumpVelocity = 5;

    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;

    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;

    //[SerializeField]
    //float fHorizontalAcceleration = 1;
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

    public float dashAmount = 10f;
    public bool facingRight = true;
    private float moveHor;
    public bool bGrounded;
    private bool isPaused = false;
    Rigidbody2D rb;
    Animator anim;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        PlayerMove();
        Jump();
        Dash();
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) {
            Time.timeScale = 0;
            print("hey");
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) {
            Time.timeScale = 1;
            print("hea");
            isPaused = false;
        }
    }
    void PlayerMove()
    {
        // Controls
        moveHor = Input.GetAxis("Horizontal");

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
        if (anim.GetBool("isRunning") == true && bGrounded){
            if (!audioSource.isPlaying){
                audioSource.Play();
            }
        }
        else {
            audioSource.Stop();
        }

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
        //Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + new Vector2(0, -0.01f);
        //Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + new Vector2(-0.02f, 0);
        //bool bGrounded = Physics2D.OverlapBox(v2GroundedBoxCheckPosition, v2GroundedBoxCheckScale, 0, lmWalls);

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
            bGrounded = false;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }
   
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (facingRight)
                rb.MovePosition(transform.position + new Vector3(dashAmount, 0));
            else
                rb.MovePosition(transform.position - new Vector3(dashAmount, 0));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Enemy") {
            bGrounded = true;
        }
    }


}
