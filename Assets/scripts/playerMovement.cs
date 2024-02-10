using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class playerMovement : MonoBehaviour
{
    public enum movementState { idle, running, jumping, falling };

    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Animator anim;
    private float dirX;

    [SerializeField] private LayerMask jumpGround;
    
    [SerializeField] private float jumpHeight=25f;
    [SerializeField] private float moveSpeed=10f;
    
    
 
   
 
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        coll=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal");

        rb.velocity=new Vector2(dirX*moveSpeed,rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && isOnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        movementState state;
        // sprite.flipX = dirX < 0f;
        // state = dirX == 0 ? movementState.idle : movementState.running;
        if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX=false;
        }
        else if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX=true;
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

        anim.SetInteger("state",(int)state);
    }
    private bool isOnGround()
        {
           return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpGround);
        }
    
}
