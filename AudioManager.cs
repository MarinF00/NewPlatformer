using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;





public class AudioManager : MonoBehaviour
{
    public static AudioClip playerHitSound, coinPickUpSound,levelComplete;
    static AudioSource audioSrc;

    public object Recources { get; private set; }

    private void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("hit_30");
        coinPickUpSound = Resources.Load<AudioClip>("coin_30");
        levelComplete = Resources.Load<AudioClip>("complete");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "coin_30":
                audioSrc.PlayOneShot(coinPickUpSound);
                break;

            case "hit_30":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "complete":
                audioSrc.PlayOneShot(levelComplete);
                break;
        }
    }
}
