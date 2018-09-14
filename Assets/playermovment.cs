
using UnityEngine;

public class playermovment : MonoBehaviour {
    public Rigidbody2D rb;
    public float runspeed = 100f;
    public float jump = 1f;
    public bool grounded = true;
    public bool facingright;
    public Animator animator;
    public bool jumprequest = false;
    public float sprintspeed;
    public float boost;
    public float jumpingboost = 1;
    public bool isbig = false;
    public Sprite BigSprite;
    public BoxCollider2D bigboxcollider;
    public float zeroToMax = 5f;
    float accelRatePerSec;
    float forwardvelocity;




   



    private void Awake()
    {
       
       
    }

    private void Start()
    {
        accelRatePerSec = runspeed / zeroToMax;
        facingright = true;
        rb = GetComponent<Rigidbody2D>();
        bigboxcollider.enabled = false;
    }

    public void isbigtrue(){

        isbig = true;
        }

    private void Update()
    {
        if (isbig)
        {
            rb.GetComponent<SpriteRenderer>().sprite = BigSprite;
            bigboxcollider.enabled = true;
            
            jump = 10f;
            rb.GetComponent<BetterJump>().SetFallmultiplier(8f);
            rb.GetComponent<BetterJump>().SetLowJumpMultiplier(6f);
            animator.SetBool("isBig", true);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumprequest = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "coin")
        {

           
            collision.collider.GetComponent<Questionblock>().QuestionBlockBounce(transform.localPosition.y);
        }
    }
    void FixedUpdate()
    {

        Debug.Log(rb.velocity.x);
        animator.SetFloat("yspeed",rb.velocity.y);
        float horizontalmovment = Input.GetAxisRaw("Horizontal");
        if (jumprequest)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);

            jumpingboost =boost;
            jumprequest = false;
        }
        if (grounded)
        {
            jumpingboost =1;

        }
        else
        {
            jumpingboost =boost;
        }
            
        if (!grounded) { 
        if (horizontalmovment > 0 && !facingright || horizontalmovment < 0 && facingright)
        {
            horizontalmovment = horizontalmovment*0.5f;
        }
        }

        if(horizontalmovment == 0)
        {
            forwardvelocity = 0f;
        }
        forwardvelocity += accelRatePerSec * Time.deltaTime;
        forwardvelocity = Mathf.Min(forwardvelocity, runspeed);

        horizontalmovment = Input.GetKey(KeyCode.LeftShift) ? horizontalmovment * sprintspeed: horizontalmovment * forwardvelocity;






        animator.SetFloat("speed", Mathf.Abs(horizontalmovment));
        
        HandleMovement(horizontalmovment);
        Flip(horizontalmovment);
    }
    private void OnTriggerEnter2D()
    {
        grounded = true;
    }
    private void OnTriggerExit2D()
    {
        
        grounded = false;
       
    }
    private void HandleMovement(float f)
    {
        if (!grounded) {
            


        rb.velocity = new Vector2(f, rb.velocity.y);
            
        }
        else
        {
            rb.velocity = new Vector2(f, rb.velocity.y);
        }


    }
    private void Flip(float horizontal)
    {
        if (grounded) { 
        if(horizontal > 0 && !facingright || horizontal< 0 && facingright)
        {
            facingright = !facingright;

            Vector3 thescale = transform.localScale;
            thescale.x = thescale.x * -1;

            transform.localScale = thescale;
        }
        }
        
    }
}
