using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmailManager : MonoBehaviour
{
    [SerializeField]
    EmailCollection startingEmails, threatEmail;

    [SerializeField]
    Transform emailHolder;

    [SerializeField]
    GameObject emailWindow, lightWindow, emailPrefab;

    [SerializeField]
    Scrollbar contentScrollbar;

    [SerializeField]
    private Text headerText, bodyText;
    public static EmailManager emailManager;

    void Awake()
    {
        if(emailManager == null)
        {
            emailManager = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        EmailManager.emailManager.AddEmailCollection(startingEmails, 20f);
        EmailManager.emailManager.AddEmailCollection(threatEmail, 100f);
        lightWindow.SetActive(false);
    }



    public void SetEmail(Email e)
    {
        string subject = e.subject.ToUpper();
        string sender = e.sender.ToUpper();
        string senderEmail = e.senderEmail.ToUpper();
        string body = e.body;

        headerText.text = $"<b>FROM:</b> {senderEmail}\n<b>SUBJECT:</b> {subject}";
        bodyText.text = body;
        contentScrollbar.value = 1;
    }

    public void AddNewEmail(Email e)
    {   
        GameObject emailObject = Instantiate(emailPrefab, emailHolder.position, emailHolder.rotation);
        
        emailObject.GetComponent<EmailButton>().SetEmail(e);
        emailObject.transform.SetParent(emailHolder);
        emailObject.transform.localScale = new Vector3(1,1,1);
    }

    public void AddEmailCollection(EmailCollection ec, float waitTime)
    {
        StartCoroutine(_AddEmailCollection(ec, waitTime));
    }

    IEnumerator _AddEmailCollection(EmailCollection ec, float waitTime)
    {
        print("Adding emails but waiting " + waitTime + " seconds");
        yield return new WaitForSeconds(waitTime);

        print("trying to loop through email");

        foreach(Email e in ec.emails)
        {
            AddNewEmail(e);
        }

        NotificationController.notificationController.SetText("YOU'VE GOT MAIL!\n\nPRESS 0 TO CHECK");
        NotificationController.notificationController.Play("Notification");
        SoundManager.soundManager.PlaySound("notification");

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWindowVisible(bool b)
    {
        print("window vis: " + b);
        emailWindow.SetActive(b);
    }

    public void SetLightWindow(bool b)
    {
        lightWindow.SetActive(b);
    }
}
