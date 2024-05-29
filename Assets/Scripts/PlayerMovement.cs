using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpHeight;

    public float horizontal;
    public bool isFacingRight = true;

    bool isRight;
    bool isLeft;
    bool isReleased;

    private Rigidbody2D rb;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void FixedUpdate()
    {
        if (isRight)
        {
            horizontal = 1;
        }

        if (isLeft)
        {
            horizontal = -1;
        }

        if (isReleased)
        {
            horizontal = 0;
        }

        rb.velocity = new Vector2(horizontal * runSpeed * Time.deltaTime, rb.velocity.y);

        Flip();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    

    public void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0) 
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            Coin.instance.AddCoin();
            Destroy(collision.gameObject);
        }
    }

    public void LeftButton()
    {
        isLeft = true;
        isRight = false;
        isReleased = false;
    }

    public void RightButton()
    {
        isLeft = false;
        isRight = true;
        isReleased = false;
    }

    public void ButtonReleased()
    {
        isLeft = false;
        isRight = false;
        isReleased = true;
    }

    public void jump()
    {
        if (IsGrounded())
        {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    
}
