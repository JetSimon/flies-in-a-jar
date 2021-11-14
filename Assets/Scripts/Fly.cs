using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Rigidbody rb;
    float cooldown = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cooldown <= 0)
        {
            PickNewDirection();
            cooldown = Random.Range(3f,5f);
        }

        cooldown -= Time.deltaTime;
        rb.AddForce(transform.up);
        rb.AddForce(transform.right * Mathf.Sin(Time.time));
    }

    void PickNewDirection()
    {
        transform.Rotate(0,0,Random.Range(-90,180));
    }
}
