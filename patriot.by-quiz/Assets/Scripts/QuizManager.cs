using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
   public List<QandA> QnA;
   public GameObject[] options;
   public int currentQuestion;
   private AnswersScript answersScript;

   public GameObject finishPanel;

   public TMP_Text questionText;

   private void Start()
   {
      GenerateQuestion();
   }

   public void Correct()
   {
      StartCoroutine(Answer());
   }

   void SetAnswers()
   {
      for (int i = 0; i < options.Length; i++)
      {
         answersScript = options[i].GetComponent<AnswersScript>();
         options[i].GetComponent<AnswersScript>().isCorrect = false;
         options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].answers[i];

         if (QnA[currentQuestion].correctAnswer == i+1)
         {
            options[i].GetComponent<AnswersScript>().isCorrect = true;
         }
      }
   }
   public IEnumerator Answer()
   {
      yield return new WaitForSeconds(0.75f);
      answersScript.ResetColor();
      QnA.RemoveAt(currentQuestion);
      GenerateQuestion();
   }
   
   void GenerateQuestion()
   {
      if (QnA.Count > 0)
      {
         currentQuestion = Random.Range(0, QnA.Count);

         questionText.text = QnA[currentQuestion].question;
         SetAnswers();
      }
      else
      {
         finishPanel.SetActive(true);
         answersScript.counter.SetScore();
      }
   }
}
