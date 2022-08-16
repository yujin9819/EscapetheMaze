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

    private void Start()
    {
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
    }

    private void Update()
    {
        txt_gemCnt.text = gemCnt.ToString() + " / " + gemMaxCnt.ToString();
        if (gemCnt == gemMaxCnt)
        {
            exit.SetActive(true);
        }
    }
}
