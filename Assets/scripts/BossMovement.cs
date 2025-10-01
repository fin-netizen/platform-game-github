using System.Threading;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    Rigidbody2D rb;
    public bool isFacingRight;
    bool isGrounded;
    public LayerMask groundLayer;
    float xvel, yvel;
    float timer;
    public PlayerScript playerscript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xvel = -1.5f;
        yvel = 0f;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        yvel = rb.linearVelocity.y;
        DoJump();

        

        //groundcheck for enemy moving left
        if (xvel < 0)
        {
            if (ExtendedRayCollisionCheck(-1, 0) == false)
            {
                //do the flip
                flip();
                xvel = -xvel;
            }
        }
        if (xvel > 0)
        {
            if (ExtendedRayCollisionCheck(2, 0) == false)
            {
                flip();
                xvel = -xvel;
            }
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (!isFacingRight && xvel < 0f)
        {
            flip();
        }
        else if (isFacingRight && xvel > 0f)
        {
            flip();
        }
        if (xvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (yvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        

    }
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {

            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
    void DoJump()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            yvel = 9;
            timer = 10;
            print("Boss says: traitor");
        }
       
    }
    
    

}
