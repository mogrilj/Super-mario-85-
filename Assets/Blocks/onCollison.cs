using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollison : MonoBehaviour
{


    public Rigidbody2D rb;
    public GameObject smallplayer;


    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "mushroom")
        {
            smallplayer.GetComponent<playermovment>().isbigtrue();
        }
    }
}
