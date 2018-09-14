
using UnityEngine;

public class OnMushroomHit : MonoBehaviour {


    public Rigidbody2D rb;
    public GameObject gameObject;
    public float horizontalmovment = 1;
    public bool hit = false;
	// Use this for initialization
	void Start () {
        rb = transform.GetComponent<Rigidbody2D>();
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
       


        if (collision.collider.tag == "player")
        {
           
            Destroy(gameObject);
        }
        if(collision.collider.tag == "pipe")
        {

          
            hit = true;

            
            horizontalmovment *= -1f;

        }
    }
    private void Update()
    {
        if (hit)
        {

        
            rb.velocity = new Vector2(150*horizontalmovment*Time.deltaTime,rb.velocity.y);
        }
    }

}
