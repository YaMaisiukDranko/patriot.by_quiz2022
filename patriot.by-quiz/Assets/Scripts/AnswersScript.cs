using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect;
    public QuizManager quizManager;

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void AnswerChecker()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.Correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            quizManager.Wrong();
        }
    }

    public void ResetColor()
    {
        GetComponent<Image>().color = startColor;
    }
}
