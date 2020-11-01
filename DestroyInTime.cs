using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{

    

    [SerializeField]
    public AudioSource bulletExplosion;
    float destroyTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        bulletExplosion = GetComponent<AudioSource>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("ground"))
        {
   
            Destroy(gameObject);
            Explode();
        }
    }

    public void Explode()
    {
        bulletExplosion.Play();
    }
}
