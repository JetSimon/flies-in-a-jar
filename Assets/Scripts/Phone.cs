using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    EmailCollection room2Dump, room3Dump;

    [SerializeField]
    CCTVController cctvController;

    [SerializeField]
    Text phoneText;

    string currentNumber = "";

    bool dialing = false;

    void Start()

    {
         phoneText.text = "";
    }

    public void AddNumber(string s)
    {
        if(dialing) return;

     

        SoundManager.soundManager.PlaySound("phonepress");
        SoundManager.soundManager.StopSound("dialtone");
        currentNumber += s;
           
        string displayedNumber = currentNumber;

        if(currentNumber.Length >= 4)
        {
            displayedNumber = displayedNumber.Insert(3, "-");
        }

        if(currentNumber.Length >= 7)
        {
            displayedNumber = displayedNumber.Insert(7, "-");
        }

        phoneText.text = displayedNumber;

        if(currentNumber.Length >= 10 || currentNumber == "911")
        {
            Dial(currentNumber);
        }
    }

    void Dial(string number)
    {
         
        dialing = true;
        print("Dialing " + number + "...");
        currentNumber = "";
        
        if(number == "5559909413")
        {
            cctvController.Unlock("CAM-02");
            StartCoroutine(WaitForDial());
            EmailManager.emailManager.AddEmailCollection(room2Dump,10f);
            SoundManager.soundManager.PlaySound("room 2");
        }
        else if(number == "5513753413")
        {
            cctvController.Unlock("CAM-03");
            StartCoroutine(WaitForDial());
            EmailManager.emailManager.AddEmailCollection(room3Dump,5f);
            SoundManager.soundManager.PlaySound("room 3");
            playerController.enabled = true;
            playerController.transform.Find("Main Camera").GetComponent<Animator>().SetTrigger("Rotate");
            NotificationController.notificationController.Notify("YOU CAN MOVE", 10f);
            SoundManager.soundManager.PlaySound("security");
        }
        else if(number == "911")
        {
            StartCoroutine(WaitForDial());
            SoundManager.soundManager.PlaySound("911");
        }
        else
        {
            //if not a real number
            SoundManager.soundManager.PlaySound("dialtone");
        }
        StartCoroutine(WaitForDial());

    }

     IEnumerator WaitForDial()
    {
        yield return new WaitForSeconds(2f);

        dialing = false;
        phoneText.text = "";

        yield break;
    }

}
