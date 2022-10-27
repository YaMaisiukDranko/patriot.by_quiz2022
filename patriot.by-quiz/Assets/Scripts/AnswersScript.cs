using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect;
    public QuizManager quizManager;

    public Color startColor;
    public ScoreCounter counter;
    
    Color correctCol;
    Color wrongCol;
    
    private void Start()
    {
        startColor = GetComponent<Image>().color;
        counter = quizManager.gameObject.GetComponent<ScoreCounter>();
    }

    public void AnswerChecker()
    {
        ColorUtility.TryParseHtmlString("#74D3AE", out correctCol);
        ColorUtility.TryParseHtmlString("#FF3366", out wrongCol);
        if (isCorrect)
        {
            GetComponent<Image>().color = correctCol;
            Debug.Log("Correct Answer");
            quizManager.Correct();
            counter.score++;
        }
        else 
        {
            GetComponent<Image>().color = wrongCol;
            Debug.Log("Wrong Answer");
            quizManager.Correct();
            ShowCorrect();
        }
    }
    
    public void ResetColor()
    {
        for (int i = 0; i < quizManager.options.Length; i++)
        {
            quizManager.options[i].GetComponent<Image>().color = startColor;
        }
    }

    void ShowCorrect()
    {
        if (GameObject.FindWithTag("Answer").GetComponent<AnswersScript>().isCorrect)
        {
            GameObject.FindWithTag("Answer").GetComponent<Image>().color = correctCol;
        }
    }
}
