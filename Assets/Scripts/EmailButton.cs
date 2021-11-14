using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmailButton : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    Text text;

    [SerializeField]
    Sprite openImage;

    [SerializeField]
    private Email email;

    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        text.text = $"<b>{email.subject.ToUpper()}</b>\nFROM: {email.sender.ToUpper()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEmail(Email e)
    {
        email = e;
    }

    public Email GetEmail()
    {
        return email;
    }

    public void SetAsCurrentEmail()
    {
        image.sprite = openImage;
        EmailManager.emailManager.SetEmail(email);
    }

    public void PlaySound()
    {
        sfx.pitch = Random.Range(0.75f, 1.1f);
        sfx.Play();
    }
}
