using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Events();
    }

    private void Events()
    {
        EventManager.instance.AddEvent("DoorOpen", p =>
        {
            anim.SetBool("isDoorOpen", true);
        });

        //EventManager.instance.AddEvent("Reset", p =>
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //});
    }
}
