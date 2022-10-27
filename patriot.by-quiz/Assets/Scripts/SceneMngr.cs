using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public Animator fadeIn;
    public GameObject fader;

    public void FadeIn()
    {
        fader.SetActive(true);
        fadeIn.SetTrigger("FadeIn");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2);
        if (SceneManager.GetActiveScene().buildIndex == 0) //Check Scene Number
        {
            SceneManager.LoadScene(1);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
       
    }
}
