using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NotificationController : MonoBehaviour
{
    [SerializeField]
    Text notificationText;
    public static NotificationController notificationController;

    [SerializeField]
    Animator fuzzAnimator;
    // Start is called before the first frame update
     void Awake()
    {
        if(notificationController == null)
        {
            notificationController = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void Play(string s)
    {
        transform.Find(s).GetComponent<Animator>().SetTrigger("Activate");
    }

    public void SetText(string s)
    {
        notificationText.text = s;
    }

    public void Notify(string s)
    {
        SetText(s);
        SoundManager.soundManager.PlaySound("notification");
        Play("Notification");
    }

    public void Notify(string s, float t)
    {
        StartCoroutine(NotifyWait(s,t));
    }

    IEnumerator NotifyWait(string s, float t)
    {
        yield return new WaitForSeconds(t);
        SetText(s);
        SoundManager.soundManager.PlaySound("notification");
        Play("Notification");
        yield break;
    }

    public void WinGame()
    {
        print("Winner");
        StartCoroutine(SwitchScene("WinScreen",1f));

    }

    
    IEnumerator SwitchScene(string s, float t)
    {
        fuzzAnimator.SetTrigger("Fade");
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("WinScreen");
        yield break;
    }
}
