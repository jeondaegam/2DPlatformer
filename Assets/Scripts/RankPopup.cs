using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankPopup : MonoBehaviour
{
    public TextMeshProUGUI scoresLabel;

    public void OnEnable()
    {
        ShowScores();
    }


    // 저장된 스코어를 보여준다.
    private void ShowScores()
    {
        string[] scores = PlayerPrefs.GetString("HighScores", "").Split(",");
        string result = "";

        if (scores.Length > 0)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                result += $"{i + 1}. {scores[i]}\n";
            }

        }

        scoresLabel.text = result;
    }


    public void PressedCloseButton()
    {
        gameObject.SetActive(false);
    }
}
