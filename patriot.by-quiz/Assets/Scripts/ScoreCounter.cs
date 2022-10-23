using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    
    public void SetScore()
    {
        scoreText.text = score.ToString();
    }
}
