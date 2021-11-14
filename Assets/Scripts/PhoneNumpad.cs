using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneNumpad : MonoBehaviour
{
    public string label;
    private Vector3 pos;

    float offset = 0;

    void Start()
    {
        pos = transform.position;
    }
    
    void OnMouseDown()
    {
        print(label);
        offset = 0.05f;
        
        transform.parent.GetComponent<Phone>().AddNumber(label);
    }

    void Update()
    {
        if(offset > 0) offset -= Time.deltaTime / 5;
        if(offset < 0) offset = 0;
        transform.position = pos - new Vector3(0,offset,0);
    }
}
