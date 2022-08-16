using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject setting;
    public GameObject pause;

    public void Return()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Setting()
    {
        pause.SetActive(false);
        setting.SetActive(true);
    }

    public void Done()
    {
        setting.SetActive(false);
        pause.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
