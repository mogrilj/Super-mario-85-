using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionblock : MonoBehaviour
{


    public float bounceheight = 0.5f;
    public float bouncespeed = 4f;
    public bool canbounce = true;
    public bool iscoinblock = true;
    public float coinmovespeed = 8f;
    public float coinmoveheight = 3f;
    public float coinfalldistance = 2f;

    public float mushroomspeed = 2f;
    public bool mushroomishere = false;
    public Rigidbody2D Mushroomrb;
    public Sprite emptysprite;
    public Vector2 originalposition;
    // Use this for initialization
    void Start()
    {
        originalposition = transform.localPosition;
    }


    
    public void QuestionBlockBounce(float position)
    {
        if(position <= transform.localPosition.y) { 
        if (canbounce)
        {
            canbounce = false;
            StartCoroutine(Bounce());
        }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (mushroomishere)
        {
            Mushroomrb.velocity = new Vector2(mushroomspeed, Mushroomrb.velocity.y);
        }
    }
    void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptysprite;
        ;

    }
    void PresentCoin()
    {
        GameObject spinningcoin = (GameObject)Instantiate(Resources.Load(("GameObject"), typeof(GameObject)));

        spinningcoin.transform.SetParent(this.transform.parent);

        spinningcoin.transform.localPosition = new Vector2(originalposition.x+1.05f, originalposition.y+0.8f);

        StartCoroutine(movecoin(spinningcoin));
       


    }
    void PresentMushroom()
    {
        GameObject mushroom = (GameObject)Instantiate(Resources.Load(("mushroom"), typeof(GameObject)));
        mushroom.transform.SetParent(this.transform.parent);

        mushroom.transform.localPosition = new Vector2(originalposition.x, originalposition.y+0.1f);


         Mushroomrb = mushroom.GetComponent<Rigidbody2D>();

        mushroomishere = true;
       
    }

    IEnumerator Bounce()
    {


        ChangeSprite();
        if (iscoinblock) { 
        PresentCoin();
        }
        else
        {
            PresentMushroom();
        }
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bouncespeed * Time.deltaTime);

            if (transform.localPosition.y >= originalposition.y + bounceheight)
            {
                break;
            }
            yield return null;

        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bouncespeed * Time.deltaTime);

            if (transform.localPosition.y <= originalposition.y)
            {
                transform.localPosition = originalposition;
                break;
            }
            yield return null;
        }


    }
    IEnumerator movecoin(GameObject coin)
    {
        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y + coinmovespeed * Time.deltaTime);


            if (coin.transform.localPosition.y >= originalposition.y + coinmoveheight)
            {
                break;

            }
            yield return null;
            
        }
        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y - coinmovespeed * Time.deltaTime);
            if(coin.transform.localPosition.y <= originalposition.y +coinfalldistance)
            {
                Destroy(coin.gameObject);
                break;
            }
            yield return null;
        }

    }
    IEnumerator SpawnMushroom(GameObject mushroom)
    {
        while (true)
        {
           

            
        }
    }
}
