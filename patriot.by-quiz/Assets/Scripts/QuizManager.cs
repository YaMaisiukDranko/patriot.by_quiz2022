using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
   public List<QandA> QnA;
   public GameObject[] options;
   public int currentQuestion;

   public TMP_Text questionText;

   void SetAnswers()
   {
      for (int i = 0; i < options.Length; i++)
      {
         options[i].GetComponent<AnswersScript>().isCorrect = false;
         options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].answers[i];

         if (QnA[currentQuestion].correctAnswer == i++)
         {
            options[i].GetComponent<AnswersScript>().isCorrect = true;
         }
      }
   }
   
   void generateQuestion()
   {
      currentQuestion = Random.Range(0, QnA.Count);

      questionText.text = QnA[currentQuestion].question;
   }
}
