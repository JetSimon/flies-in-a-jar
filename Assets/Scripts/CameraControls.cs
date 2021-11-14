using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    AudioSource sound;
    [SerializeField]
    float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,Input.GetAxis("Horizontal") * -Time.deltaTime * rotateSpeed,0,Space.World );

        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && !sound.isPlaying) sound.Play();
        if(Input.GetAxis("Horizontal") == 0) sound.Stop(); 
    }
}
