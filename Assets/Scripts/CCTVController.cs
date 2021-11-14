using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CCTVController : MonoBehaviour
{
    [SerializeField]
    GameObject defaultCam, player;
    
    [SerializeField]
    private CCTV[] cams;
    private CCTV currentCam, lastCam;

    [SerializeField]
    Text camText, timeText;

    [SerializeField]
    Animator fuzzAnimator;

    Vector3 playerStart;



    // Start is called before the first frame update
    void Start()
    {
        foreach(CCTV cam in cams)
        {
            cam.cameraGameObject.SetActive(false);
        }    

        fuzzAnimator.gameObject.SetActive(true);
        defaultCam.SetActive(true);
        playerStart = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerStart, player.transform.position) > 1f) return;
        foreach(CCTV cam in cams)
        {
            if(cam.locked) continue;
            if(Input.GetKeyDown(cam.key))
            {
                if(lastCam != null && cam.key == "tab" && currentCam.key == "tab")
                {
                    SetActiveCCTV(lastCam);
                }
                else
                {
                    SetActiveCCTV(cam);
                }
            }
        }
    }

    void SetActiveCCTV(CCTV activeCam)
    {
        lastCam = currentCam;
        currentCam = activeCam;
        
        GetComponent<AudioSource>().Play();
        fuzzAnimator.SetTrigger("ChangeScene");
        activeCam.cameraGameObject.SetActive(true);
        foreach(CCTV cam in cams)
        {
            if(cam != activeCam)
            {
                cam.cameraGameObject.tag = "None";
                cam.cameraGameObject.SetActive(false);
            }else{
                cam.cameraGameObject.tag = "MainCamera";
                activeCam.cameraGameObject.SetActive(true);
            }
        }    

        timeText.GetComponent<CameraTimer>().SetVisible(activeCam.showTime);
        camText.text = activeCam.camName;
    }

    public void Unlock(string camName)
    {
        
        foreach(CCTV cam in cams)
        {
            if(cam.camName == camName && cam.locked)
            {
                NotificationController.notificationController.Notify("NEW CCTV UNLOCKED\n\nPRESS " + cam.key + " TO VIEW");
                cam.locked = false;
            } 
        }
    }
}

[System.Serializable]
public class CCTV 
{
    public GameObject cameraGameObject;
    public string key, camName;

    public bool showTime = true;

    public bool locked = false;
}