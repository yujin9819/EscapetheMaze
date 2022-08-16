using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gemMaxCnt;
    public int gemCnt = 0;
    public Text txt_gemCnt;
    public GameObject exit;
    public GameObject gem;

    public GameObject pauseUI;

    private void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Events();
    }

    private void Events()
    {
        EventManager.instance.AddEvent("CollectTheGem", p => gemCnt++);
        EventManager.instance.AddEvent("Reset", p =>
        {
            gemCnt = 0;
            Destroy(GameObject.Find("Gem"));
            var c = Instantiate(gem);
            c.name = "Gem";
            exit.SetActive(false);
        });
        EventManager.instance.AddEvent("Return", p => pauseUI.SetActive(false));
    }

    private void Update()
    {
        txt_gemCnt.text = gemCnt.ToString() + " / " + gemMaxCnt.ToString();
        if (gemCnt == gemMaxCnt)
        {
            exit.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            //Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
    }
}
