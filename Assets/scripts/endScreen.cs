using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestText;
    
    void Start()
    {
        var score = PlayerPrefs.GetInt("mybirdscore");
        scoreText.text = score.ToString();

        var best = PlayerPrefs.GetInt("Best");
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("Best", score);
        }

        bestText.text = best.ToString();
    }

    

    
}
