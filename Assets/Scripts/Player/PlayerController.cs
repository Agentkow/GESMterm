using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;

    private bool grounded = false;
    public Transform groundCheck;

    [SerializeField]
    private float groundRadius = 0.35f;

    [SerializeField]
    public LayerMask whatIsGround;

    [SerializeField]
    private float jumpForce = 2500;

    [SerializeField]
    private float drag = 15;
    [SerializeField]
    private float notDrag = 0.1f;

    private bool canFloat = false;

    

    private AudioSource audioSource;

    
    //bool doubleJump = false;

    private Rigidbody2D rb;


    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        rb = this.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void FixedUpdate() {

        Collider2D[] groundColider =
            Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);

        grounded = groundColider.Length > 0;

        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {

            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
            audioSource.Play();


        }
        if (!grounded && Input.GetButton("Float") && canFloat)
        {
            rb.drag = drag;
        }
        else
        {
            rb.drag = notDrag;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Pickup"))
        {
            collision.gameObject.SetActive(false);
            canFloat = true;
            

        }
        if(collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
