using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Email", order = 1)]

public class Email : ScriptableObject
{

    public string sender, senderEmail, subject;
    
    [TextArea]
    public string body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
