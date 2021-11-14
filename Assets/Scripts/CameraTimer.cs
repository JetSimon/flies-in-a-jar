using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraTimer : MonoBehaviour
{
    bool visible = true;
    float time = 18 * 60 * 60;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        int hours = (int)(time / 60 / 60);
        if(hours > 24) time = 0;
        int mins = (int)(time / 60) % 60;
        int secs = (int)(time) % 60;
       // Debug.Log(secs);
        string spacer1 = hours < 10 ? "0" : "";
        string spacer2 = mins < 10 ? "0" : "";
        string spacer3 = secs < 10 ? "0" : "";
        string timeString = spacer1+hours+":"+spacer2+mins+":"+spacer3+secs;

        if(visible)
        text.text = "05/11/07 " + timeString;
        else text.text ="";
    }

    public void SetVisible(bool b)
    {
        visible = b;
    }
}
