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

   public TMP_Text questionText;

   private void Start()
   {
      GenerateQuestion();
   }

   public void Correct()
   {
      StartCoroutine(Answer());
   }

   public IEnumerator Answer()
   {
      yield return new WaitForSeconds(0.75f);
      QnA.RemoveAt(currentQuestion);
      GenerateQuestion();
   }
   
   void SetAnswers()
   {
      for (int i = 0; i < options.Length; i++)
      {
         options[i].GetComponent<AnswersScript>().isCorrect = false;
         options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].answers[i];

         if (QnA[currentQuestion].correctAnswer == i+1)
         {
            options[i].GetComponent<AnswersScript>().isCorrect = true;
         }
      }
   }
   
   void GenerateQuestion()
   {
      currentQuestion = Random.Range(0, QnA.Count);

      questionText.text = QnA[currentQuestion].question;
      SetAnswers();
   }
}
