using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool moveRight;

    private void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0 , 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-2, 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet")) {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.tag.Equals("turn"))
        {
            if (moveRight) { 
                moveRight = false; 
            }
            else
            {
                moveRight = true;
            }
            

        }
        
    }
}
