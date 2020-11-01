using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            CoinCounter.coinAmount += 1;
        }
    }
    public static void Win()
    {
        CoinSet();
        SceneManager.LoadScene("Menu");
    }

    public static void CoinSet()
    {
        PlayerPrefs.SetInt("Coins", CoinCounter.coinAmount);
    }



}
