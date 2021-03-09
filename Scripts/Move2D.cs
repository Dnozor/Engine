using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    
    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } 
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2 (_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .08f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }

        animator.SetBool("Grounded", isGrounded);
    }
}
