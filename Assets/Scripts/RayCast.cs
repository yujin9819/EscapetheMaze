using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Transform playerCam;
    RaycastHit hit;
    public Text txtInteract;
    public bool isDoorClosed = true;
    public GameObject gemUI;

    void Update()
    {
        if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, 15f))
        {
            if (isDoorClosed)
            {
                if (hit.collider.CompareTag("Info"))
                {
                    txtInteract.text = "F키를 눌러 문 열기";

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        EventManager.instance.SendEvent("DoorOpen");
                        isDoorClosed = false;
                        gemUI.SetActive(true);
                    }
                }
            }
            if (!hit.collider.CompareTag("Info"))
            {
                txtInteract.text = "";
            }
        }
    }
}
