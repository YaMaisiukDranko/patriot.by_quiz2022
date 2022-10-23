using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    private QuizManager quizManager;
    private int questions;

    private void Start()
    {
        quizManager = GetComponent<QuizManager>();
        questions = quizManager.QnA.Count;
    }

    public void SetScore()
    {
        scoreText.text = score + "/" + questions;
    }
}
