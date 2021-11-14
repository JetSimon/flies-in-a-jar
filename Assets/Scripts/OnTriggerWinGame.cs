using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerWinGame : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") NotificationController.notificationController.WinGame();
    }
}
