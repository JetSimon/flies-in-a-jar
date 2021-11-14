using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextPassword : MonoBehaviour
{
    [SerializeField]
    string password;

    [SerializeField]
    GameObject objectToHide;

    [SerializeField]
    InputField input;

    [SerializeField] CircuitController circuitController;

    public void TryPassword()
    {
        if(input.text.ToLower() == password.ToLower())
        {
            objectToHide.SetActive(false);
            SoundManager.soundManager.PlaySound("notification");
            if(circuitController != null) circuitController.UpdatePower();
        }else{
            SoundManager.soundManager.PlaySound("error");
            input.text = "";
        }   


        


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
