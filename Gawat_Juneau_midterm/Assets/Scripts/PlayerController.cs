using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;
    private float movement;
    private Vector3 player;
    private Vector3 flip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = transform.localScale;
    }

    private void Update()
    {
        if(isGrounded == true)
        {
            anim.SetBool("isGrounded", true);
        } else
        {
            anim.SetBool("isGrounded", false);
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Skip"))
        {
            anim.SetBool("isDucking",true);
        } else
        {
            anim.SetBool("isDucking", false);
        }

        if(rb.velocity.x > 1)
        {
            anim.SetFloat("xSpeed", 1);
            anim.SetBool("isDucking", false);
            FlipChar(1);
        } else if(rb.velocity.x < -1)
        {
            anim.SetFloat("xSpeed", 1f);
            anim.SetBool("isDucking", false);
            FlipChar(-1);
        }
        else
        {
            anim.SetFloat("xSpeed", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position += movement * Time.deltaTime * moveSpeed;
        movement = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(movement * moveSpeed, rb.velocity.y));
        Jump();
    }

    void FlipChar(float dir)
    {
        flip = new Vector3(dir,player.y,player.z);

        transform.localScale = flip;
    }

    void Jump()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
