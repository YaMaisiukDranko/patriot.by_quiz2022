using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsAndAnswers", menuName = "Q&A Object")]
[Serializable]
public class QandA : ScriptableObject
{
    public string question;
    public string[] answers;
    public int correctAnswer;
}
