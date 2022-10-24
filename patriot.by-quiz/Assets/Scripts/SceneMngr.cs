using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public Animator fadeIn;
    public Animator fadeOut;
    public GameObject fader;

    public void FadeIn()
    {
        fader.SetActive(true);
        fadeIn.SetTrigger("FadeIn");
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }
}
