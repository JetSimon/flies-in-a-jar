using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSounds : MonoBehaviour
{
    private AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            sfx.pitch = Random.Range(0.8f, 1.1f);
            sfx.Play();
        }
    }
}
