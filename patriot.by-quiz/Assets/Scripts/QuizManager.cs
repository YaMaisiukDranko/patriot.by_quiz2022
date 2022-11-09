using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
   public List<QandA> QnA;
   public GameObject[] options;

   public int currentQuestion;
   private int questionNum;
   
   private AnswersScript answersScript;
   private ScoreCounter sc;
   
   public GameObject finishPanel;
   public GameObject gamePanel;

   public TMP_Text questionText;
   public TMP_Text questionNumber;

   //Animations
   public GameObject fader;
   public Animator fadeOutAnimator;
   
   [SerializeField] GameObject fourButtons;
   [SerializeField] GameObject sixButtons;


   private void Start()
   {
      fadeOutAnimator.SetTrigger("FadeOut");
      StartCoroutine(FadeOut());
      sc = gameObject.GetComponent<ScoreCounter>();
      GenerateQuestion();
   }

   IEnumerator FadeOut()
   {
      yield return new WaitForSeconds(2);
      fader.SetActive(false);
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
      questionNum += 1;
      if (QnA.Count > 0)
      {
         //currentQuestion = Random.Range(0, QnA.Count);

         questionText.text = QnA[currentQuestion].question;
         SetAnswers();
      }
      else
      {
         finishPanel.SetActive(true);
         gamePanel.SetActive(false);
         answersScript.counter.SetScore();
      }
   }

   private void FixedUpdate()
   {
      questionNumber.text = questionNum + "/" + sc.questions;
   }
}
