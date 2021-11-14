using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    // Start is called before the first frame update
    void Awake()
    {
        if(soundManager == null)
        {
            soundManager = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string s)
    {
        transform.Find(s).GetComponent<AudioSource>().Play();
    }

    public void StopSound(string s)
    {
        transform.Find(s).GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
