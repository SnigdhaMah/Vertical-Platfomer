using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //controls
    public float speed = 5f;
    public float jumpHeight = 8f;
    public float movement = 0f;
    public bool facingRight;

    //gravity
    private Rigidbody2D rigid;

    //any object that can have position, rotation, and scale (AKA the player's feet)
    public Transform groundCheckPoint;
    //area around check point that you look at
    public float groundPointRadius;
    //what the check point comes into contact with
    public LayerMask groundLayer;

    //checks when to jump
    public bool onGround;
    private bool returnToGround;
    private int jumpCount;

    public GameObject projectile;
    //keep track of how many thrown
    public int numOfRocks = 3;
    public NumberOfRocks rockDisplay;

    //manages the animation
    public Animator animator;

    public PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //gets the rigid body component of the player so we can access it
        rigid = GetComponent<Rigidbody2D>();

        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

        if (Input.GetKeyDown(KeyCode.Tab) && numOfRocks > 0) 
        {
            //the player is throwing
            StartCoroutine("animatorCoroutine");

            //call throw script
            fireProjectile();
        }

    }

    public void movePlayer ()
    {
        //check if any objects on the ground layer are within the radius from the part on the ground
        onGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundPointRadius, groundLayer);

        //get the horizantal axis to know if the user is pressing Left or Right
        //if movement,  0 = stationary, -1 = Left, 1 = Right 
        movement = Input.GetAxis("Horizontal");

        //Vector holds (x, y), moves the character
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

        //if you go left, change the character to looking left and vice versa
        if (movement < 0 && facingRight)
        {            
            transform.Rotate(0f, 180f, 0f);

            //now face left
            facingRight = false;            

        }
        else if (movement > 0 && facingRight == false)
        {
            //if you want to go right and you are looking left
            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }

        //when the movement is not 0, the speed will be that value and the "run" animation will run
        animator.SetFloat("Speed", Mathf.Abs(movement));

        //tell the animator that to play jump animation when not on ground
        animator.SetBool("isJumping", !onGround);

        if (Input.GetButtonDown("Jump") && (onGround == true || jumpCount < 2))
        {
            //change the vertical velocity
            rigid.velocity = new Vector2(rigid.velocity.x, jumpHeight);

            jumpCount++;

        }

        //if the double jump maximized, check if the player is back on the ground before allowing more double jumps
        returnToGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundPointRadius, groundLayer);

        if (returnToGround)
        {
            //tell animator to stop jump animation
            animator.SetBool("isJumping", false);
        }

        //if they are on the ground again and they maxed their jump count, reset count
        if (jumpCount == 2 && returnToGround)
        {
            jumpCount = 0;
        }
    }

    public void fireProjectile()
    {

        Instantiate(projectile, transform.position, transform.rotation);
        numOfRocks--;
        rockDisplay.changeDisplay(numOfRocks);

    }

    public IEnumerator animatorCoroutine ()
    {
        animator.SetBool("isThrowing", true);

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("isThrowing", false);
    }
}
