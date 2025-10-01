using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator anim;
    Rigidbody2D rb;
    public bool isFacingRight;
    bool isGrounded;
    public LayerMask groundLayer;
    public int lives;
    HelperScript helper;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<HelperScript>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            helper.DoFlipObject(true);
        }
        if(Input.GetKey("d"))
        {
            helper.DoFlipObject(false);
        }
        lives = 3;
        IsGrounded();

        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;
        
        
        if (Input.GetKey("a"))
        {
            
            xvel = -4;
        }
        if (Input.GetKey("d"))
        {
            
            xvel = 4;
        }
        if (xvel >= 0.1 || xvel <= -0.1)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey("f"))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yvel = 7;
          

        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d") && isGrounded)
        {
            xvel = 7;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a") && isGrounded)
        {
            xvel = -7;
        }
        rb.linearVelocity = new Vector3(xvel, yvel, 0);
      /*
        if (!isFacingRight && xvel < 0f)
        {
            flip();
        }
        else if (isFacingRight && xvel > 0f)
        {
            flip();
        }
        */
    }
    /*
    private void flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("The player has found " + other.gameObject.name );
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
    */
    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    } 
    */


    /*
     private void OnCollisionExit2D(Collision2D collision) 
     {
         isGrounded = false;
         {
             anim.SetBool("isJumping", true);
         }
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         isGrounded = true;
             {
             anim.SetBool("isJumping", false);
             }
     }
    */


    void IsGrounded()
    {
        Color color = Color.red;
        isGrounded = false;

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
            color = Color.green;

        }

        Debug.DrawRay(position, direction, color);
        hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        
    }


    /*
    float xPos = transform.position.x;
    float yPos = transform.position.y;


    // was very annoying to get it to funtion 
   if (Input.GetKeyDown("w") == true)
    {
        yPos += 0.1f; 
    }

   if (Input.GetKeyDown("s") == true)
    {
        yPos -= 0.1f;
    }

   if (Input.GetKeyDown("d") == true)
    {
        xPos += 0.1f; 
    }

    if (Input.GetKeyDown("a") == true)
    {
        xPos -= 0.1f; 
    }
    */
    //IT WORKS YYYYYYYYEEEEEEEEEESSSSSSSSSS!!!!!
    /*
    if (yPos >= 1.5 || xPos >= 1.5)
    {
        yPos = 0;
        xPos = 0;
    }
    if (yPos <= (-1.5) || xPos <= (-1.5))
    {
        xPos = 0;
        yPos = 0;

    }
    */
    /*
    transform.position = new Vector3(xPos, yPos, 0);
    */
}

