using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        string myScore = PlayerPrefs.GetString("MyScore", "");
        string searchString = @"\d+\. " + myScore;
        string result = "";


        if (scores.Length > 0)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                result += $"{i + 1}. {scores[i]}\n";
            }

            // 내 순위가 목록에 있다면 하이라이팅
            if (result.Contains(myScore))
            {
                Debug.Log($"Found! : {myScore}");

                //string highlightedText = $"<color=yellow>{searchString}</color>";
                //result = result.Replace(searchString, highlightingText);
                // result에서 searchString과 매칭된 부분을 찾고, 그 매칭된 값(m)이 있으면 문자열 파싱
                result = Regex.Replace(result, searchString, m => $"<color=yellow>{m.Value}</color>");
            }

        }

        scoresLabel.text = result;
    }


    public void PressedCloseButton()
    {
        gameObject.SetActive(false);
    }
}
