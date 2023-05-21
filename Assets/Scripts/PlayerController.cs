using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    //Player Grahics Object
    public GameObject playerG;
    //Ground Layer Mask
    public LayerMask ground;
    public LayerMask enemies;
    
    [SerializeField]
    private Transform GroundCheck;
    
    private bool isGrounded;
    public float runSpeed = 3;
    public float jumpHeight = 10;
    private float fJumpPressedRemember = 0;
    private float fJumpPressedRememberTime = 0.2f;
    private float fGroundedRemember = 0;
    private float fGroundedRememberTime = 0.1f;
    public float fCutJumpHeight = 0.5f;
    private bool isFacingRight;
    public bool hasLeg = false;

    internal RaycastHit2D hit;

    public GameObject legp1;
    public GameObject legp2;
    public GameObject legp3;

    // Start is called before the first frame update
    void Start()
    {
        animator = playerG.GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        legp1.SetActive(hasLeg);
        legp2.SetActive(hasLeg);
        legp3.SetActive(hasLeg);

        //Get User Input and Movement
        if (Input.GetKey("right"))
        {
            isFacingRight = true;
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);

            animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            isFacingRight = false;
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);

            animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
            
            transform.eulerAngles = new Vector3(0, 180, 0);
            
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        }
        
        //Get Space Input and Jump
        fJumpPressedRemember -= Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }

        //Short Jump
        if (Input.GetKeyUp("space"))
        {
            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * fCutJumpHeight);
            }
        }

        //Ground Check
        hit = Physics2D.Linecast(transform.position, GroundCheck.position, ground);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        if (hasLeg)
        {
            runSpeed = 8f;
            jumpHeight = 13f;
        }

    }

    void FixedUpdate()
    {

        //Grounded Timer
        fGroundedRemember -= Time.deltaTime;
        if (isGrounded)
        {
            fGroundedRemember = fGroundedRememberTime;
        }

        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("ySpeed", rb2d.velocity.y, 0.1f, Time.deltaTime);

        //High Jump
        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0)) 
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            //animator.Play("jump_animation")
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Get Leg")
        {
            hasLeg = true;
            Destroy(other.gameObject);
        }
    }
}
