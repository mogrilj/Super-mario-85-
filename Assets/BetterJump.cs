using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {
    public float fallmultiplier =2.5f;
    public float lowJumpMultiplier = 2f;
    public Rigidbody2D rb;

    
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
            
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        {

        }

    }

    public void SetFallmultiplier(float f)
    {
        fallmultiplier = f;
    }
    public void SetLowJumpMultiplier(float f)
    {
        lowJumpMultiplier = f;
    }
}
