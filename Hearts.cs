using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if(livesRemaining <= 0)
        {
            FindObjectOfType<LevelManager>().Restart();
        }
    }

    private void Update()
    {
  
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            LoseLife();
        }
        
    }
}

