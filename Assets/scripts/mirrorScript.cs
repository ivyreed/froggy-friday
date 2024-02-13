using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



// public class mirrorScript : MonoBehaviour
// {
//     public enum movementState { idle, running, jumping, falling };

//     public Animator anim;
//     private Rigidbody2D rb;
//     private SpriteRenderer sprite;



//     // private Animator = mirrorAnim;
//     [SerializeField] private Transform player;

//     // Start is called before the first frame update
//     void Start()
//     {
//         // mirrorAnim = transform.GetComponent<playerMovement>;
//         // Prb = player.GetComponent<Rigidbody2D>();
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//         sprite = GetComponent<SpriteRenderer>();
//         // playerMovement.movementState.
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         transform.position = new Vector3(-player.position.x, player.position.y, player.position.z);
//         UpdateAnimationState();
//     }
//     private void UpdateAnimationState()
//     {

//         movementState state;

//         // sprite.flipX = dirX < 0f;
//         // state = dirX == 0 ? movementState.idle : movementState.running;
//         if (rb.velocity.x > .1f)
//         {
//             state = movementState.running;
//             sprite.flipX = false;
//         }
//         else if (rb.velocity.x < -.1f)
//         {
//             state = movementState.running;
//             sprite.flipX = true;
//         }
//         else
//         {
//             state = movementState.idle;
//         }
//         if (rb.velocity.y > .1f)
//         {
//             state = movementState.jumping;
//         }
//         if (rb.velocity.y < -1f)
//             state = movementState.falling;

//         anim.SetInteger("state", (int)state);


//     }
// }
public class pmirrorScript : MonoBehaviour
{
    public enum movementState { idle, running, jumping, falling };

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Animator anim;
    private float dirX;
    private float coyoteTime = .1f;
    private float coyotyTimeCounter;
    private float jumpBufferTime = .1f;
    private float jumpBufferCounter;

    [SerializeField] private LayerMask jumpGround;

    [SerializeField] private float jumpHeight = 25f;
    [SerializeField] private float moveSpeed = 10f;





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
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(-dirX * moveSpeed, rb.velocity.y);

        if (isOnGround())
        {
            coyotyTimeCounter = coyoteTime;
        }
        else
        {
            coyotyTimeCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyotyTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpBufferCounter=0f;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyotyTimeCounter = 0f;
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        movementState state;
        // sprite.flipX = dirX < 0f;
        // state = dirX == 0 ? movementState.idle : movementState.running;
        if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        if (rb.velocity.y < -.1f)
            state = movementState.falling;

        anim.SetInteger("state", (int)state);
    }
    private bool isOnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

}
