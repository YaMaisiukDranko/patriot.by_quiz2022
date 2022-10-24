using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngr : MonoBehaviour
{
    public Animator fadeIn;
    public Animator fadeOut;
    public GameObject fader;
    public void LoadGame()
    {
        fader.SetActive(true);
        fadeIn.SetTrigger("FadeIn");
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }
}
