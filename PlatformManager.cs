using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance = null;

    [SerializeField]
    GameObject platformPrefab;

    private void Awake()
    {
         if(instance == null)
        {
            instance = this;
        }
         else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Instantiate(platformPrefab, new Vector2 (25.62f, -12.84f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(27.71f, -12.84f), platformPrefab.transform.rotation);
        Instantiate(platformPrefab, new Vector2(29.99f, -12.84f), platformPrefab.transform.rotation);
    }

    
     IEnumerator spawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
