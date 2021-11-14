using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PlayerController : MonoBehaviour
{   
    [SerializeField]
    private float rotSpeed, moveSpeed;

    CharacterController controller;

    [SerializeField]
    PostProcessVolume post;

    [SerializeField]
    Transform flyObject;

    float initialDistance;

    // Start is called before the first frame update
    void Start()
    {

        initialDistance = Vector3.Distance(flyObject.position, transform.position);
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!transform.Find("Main Camera").gameObject.activeSelf) return;
        controller.Move(Input.GetAxis("Vertical") * -transform.forward * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed,0), Space.World);

        float currentDistance = Vector3.Distance(flyObject.position, transform.position);
        ChromaticAberration chromaticAberration;
        if(post.profile.TryGetSettings(out chromaticAberration))
        {
            print(currentDistance);
            chromaticAberration.intensity.value = 1 - currentDistance/initialDistance;
        }

        
    }
}
