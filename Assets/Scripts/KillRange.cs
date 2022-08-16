using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillRange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // ÀâÇúÀ¸´Ï Á×´Â°ÅÀÓ
    {
        SceneManager.LoadScene("GameOver");
        EventManager.instance.SendEvent("Reset");
    }
}
