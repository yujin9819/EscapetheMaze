using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
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
