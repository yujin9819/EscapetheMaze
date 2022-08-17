using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossArea : MonoBehaviour
{
    bool hit = true;

    private void Start()
    {
        EventManager.instance.AddEvent("EnabledCrossSfx", p =>
        {
            hit = true;
        });
    }
    private void OnTriggerEnter(Collider other)
    {
        if (hit)
        {
            if (other.CompareTag("Player"))
            {
                hit = false;
                EventManager.instance.SendEvent("Sound :: CrossTheZombie");
            }
        }
    }
}
