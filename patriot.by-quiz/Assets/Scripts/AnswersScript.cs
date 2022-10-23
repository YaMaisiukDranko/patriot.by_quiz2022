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

    private void Start()
    {
        startColor = GetComponent<Image>().color;
        counter = quizManager.gameObject.GetComponent<ScoreCounter>();
    }

    public void AnswerChecker()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.Correct();
            counter.score++;
        }
        else 
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.Correct();
        }
    }
    
    public void ResetColor()
    {
        for (int i = 0; i < quizManager.options.Length; i++)
        {
            quizManager.options[i].GetComponent<Image>().color = startColor;
        }
    }
}
