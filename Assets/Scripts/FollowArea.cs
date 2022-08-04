using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArea : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerInZombieArea");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.instance.SendEvent("PlayerOutZombieArea");
        }
    }
}
