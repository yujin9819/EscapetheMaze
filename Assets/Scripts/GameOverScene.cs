using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour
{
    public GameObject zombie;
    public GameObject text_Die;
    public GameObject text_Restart;

    private void Start()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2);
        Destroy(zombie);
        text_Die.SetActive(true);
        yield return new WaitForSeconds(1); 
        text_Restart.SetActive(true);
    }
}
