using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Animator anim;
    bool isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isDoorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDoorOpen = !isDoorOpen;

            anim.SetBool("isDoorOpen", isDoorOpen);
        }
    }
}
