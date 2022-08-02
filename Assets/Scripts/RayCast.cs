using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Transform playerCam;
    RaycastHit hit;
    public GameObject hitObj;
    public Text txtInteract;
    public bool isDoorClosed = true;

    void Update()
    {
        if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, 15f))
        {
            if (isDoorClosed)
            {
                if (hit.collider.CompareTag("Info"))
                {
                    txtInteract.text = "FŰ�� ���� �� ����";

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        EventManager.instance.SendEvent("DoorOpen");
                        isDoorClosed = false;
                        //hitObj = null;
                    }
                }
            }
            if (!hit.collider.CompareTag("Info"))
            {
                txtInteract.text = "";
                //hitObj = null;
            }
        }
    }
}