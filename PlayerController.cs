using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX;
    [SerializeField]
    float moveSpeed = 3f, jumpForce = 50f, bulletSpeed = 500f;
    bool facingRight = true;
    Vector3 localScale;
    
   


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJumps;
    public int extraJumpsValue;
    bool isDead = false;

    public Transform barrel;
    public Rigidbody2D bullet;
    PlayerController PlayerCtrl;
    public GameObject Player;
    
   /* public GameObject Body
    {
        get
        {
            return GameObject.Find("Player/body");
        }
    }
    public GameObject Helmet
    {
        get
        {
            return GameObject.Find("Player/body/Head/Hat-Helmet");
        }
    }*/

    private Animator anim;

    void Start()
    {
        
        extraJumps = extraJumpsValue;
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerCtrl = GetComponentInParent<PlayerController>();


       /* SpriteRenderer body = Body.GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer helmet = Helmet.GetComponentInChildren<SpriteRenderer>();
        Sprite newhelm = Resources.Load<Sprite>("hello");
        body.color = Color.red;
        helmet.sprite = newhelm;*/



    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpForce);
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
            Fire();
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(CrossPlatformInputManager.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        if(rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if(rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        if(isDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
      
    }
    void LateUpdate()
    {
        CheckWhereToFace();

    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else
            if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;

    }


    void Jump()
    {
        if (rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpForce);
    }

    public void Die()
    {
        isDead = true;
    }
    void Fire()
    {
        var firedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        firedBullet.AddForce(barrel.up * bulletSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("DeadlyBox"))
        {
            Die();
        }

        if (collision.gameObject.tag.Equals("Finish"))
        {
            CoinScript.CoinSet();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.PlaySound("complete");
        }

        if (collision.gameObject.tag.Equals("Win"))
        {
            CoinScript.Win();
        }



    }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Sideway"))
            {
                Player.transform.parent = other.gameObject.transform;
            }
    }
        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("Sideway"))
            {
                Player.transform.parent = null;
            }

        }

  
}
