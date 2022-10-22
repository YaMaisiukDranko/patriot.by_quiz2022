using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect;

    public void AnswerChecker()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }
}
