using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class playerMovement : MonoBehaviour
{
    public enum movementState { idle, running, jumping, falling };

    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Animator anim;
    private float dirX;
    [SerializeField] private float coyoteTime = .1f;
    private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = .1f;
    private float jumpBufferCounter;

    [SerializeField] private LayerMask jumpGround;

    [SerializeField] private float jumpHeight = 25f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private bool isMirror;
    [SerializeField] private float maxFallSpeed = 20f;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void Update()
    {

        // dirX=Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, Mathf.Clamp(rb.velocity.y, -maxFallSpeed, 100));

        dirX = isMirror ? -Input.GetAxisRaw("Horizontal") : Input.GetAxisRaw("Horizontal");

        if (isOnGround())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        sprite.flipX = dirX < 0f;
        var state = rb.velocity.y switch
        {
            > .1f => movementState.jumping,
            < -.1f => movementState.falling,
            _ => dirX == 0 ? movementState.idle : movementState.running,
        };
        anim.SetInteger("state", (int)state);
    }
    private bool isOnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

}
