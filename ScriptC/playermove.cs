using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    Rigidbody2D playerrd;
    Animator playerani;

    public float speed;
    float Velocity_x;
    //get x moving speed

    public float checkrange;
    //check radius
    public LayerMask platform;
    //check which layer is the platform
    public GameObject platformcheck;
    //need a point to check for the platform

    public bool isonplatform;
    //if player is not on ground, it will be falling

    bool playerdie;

    void Start()
    {
        playerrd = GetComponent<Rigidbody2D>();
        playerani = GetComponent<Animator>();
    }
    void Update()
    {
        isonplatform = Physics2D.OverlapCircle(platformcheck.transform.position,checkrange,platform);
        //to draw a circle from a point to check,need the center of circle, radius, layermask
        playerani.SetBool("isonplatform", isonplatform);
        Movement();
    }

    void Movement()
    {
        Velocity_x = Input.GetAxisRaw("Horizontal");
        //GetAxisRaw can return value -1,0,1

        playerrd.velocity = new Vector2(Velocity_x * speed, playerrd.velocity.y);
        //x=Velocity x * speed, y not changing

        playerani.SetFloat("speed", Mathf.Abs(playerrd.velocity.x));
        //animation of running

        if (Velocity_x !=0)
        //if x=0, cannot see the player(game character)
        {
            transform.localScale = new Vector3(Velocity_x, 1, 1);
            //player will change which way it is facing while moving left or right
        }    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform3"))
        {
            playerrd.velocity = new Vector2(playerrd.velocity.x, 10f);
            //x not changing, y is 10
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("platform4"))
        //if tag is platform4
        {
            playerani.SetTrigger("die");
            //game show player die
        }
    }

    public void PlayerDie()
    {
        playerdie = true;
        GameManager.GameOver(playerdie);
    }

    private void OnDrawGizmosSelected()
    //allow us see the lines in Gizmo
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(platformcheck.transform.position, checkrange);
    }
}

