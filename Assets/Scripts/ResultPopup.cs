using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    public TextMeshProUGUI titleLabel;
    public TextMeshProUGUI scoreLabel;

    public GameObject RankPopup;

    private void Start()
    {
        //gameObject.SetActive(false);
        // start는 최초 한번만 실행되는거 아냐 ?
        // 아 근데 처음에 꺼져있으니까 활성화 되면서 false가 되는건가 ? 
    }

    private void OnEnable()
    {
        // 일시정지 (시간 흐름을 멈춘다)

        if (GameManager.Instance.isCleared)
        {
            titleLabel.text = "CLEAR!!";
            scoreLabel.text = GameManager.Instance.timeLimit.ToString("00.00");

            SaveHighScore();
        }
        else
        {
            Time.timeScale = 0;
            titleLabel.text = "GAME OVER";
            scoreLabel.text = "";
        }

        //StartCoroutine(PauseGame());
    }

    private void SaveHighScore()
    {
        // 1. 현재 점수 가져온다
        float score = GameManager.Instance.timeLimit;
        // 2. string으로 변환
        string currentScoreString = score.ToString("00.00");
        // 3. 저장된 점수를 들고 온다 .
        string savedScores = PlayerPrefs.GetString("HighScores", "");
        // 4. 저장된 점수가 없다면 ?

        if (string.IsNullOrEmpty(savedScores))
        {
            // 5. 현재 점수 저장 
            PlayerPrefs.SetString("HighScores", currentScoreString);
        }
        else
        {
            // 6. 저장된 점수가 있다면 ?

            // 6-1. string 배열로 변환
            string[] scoreArr = savedScores.Split(",");
            // 6-2. 적정 위치 삽입을 위해 list로 변환
            List<string> scoreList = new List<string>(scoreArr);

            //6-3. 현재 점수 순위 찾기
            for (int i = 0; i < scoreList.Count; i++)
            {
                float savedScore = float.Parse(scoreList[i]);
                // 현재 점수보다 작은 점수를 발견하면
                if (savedScore < score)
                {
                    // 그 위치에 insert 한다 .
                    scoreList.Insert(i, currentScoreString);
                    // for문을 빠져나온다 
                    break;
                }
            }

            // 적절한 위치를 찾지 못한 경우 : 내 점수가 가장 낮다
            if (scoreArr.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }


            // 7. 10위까지만 저장한다 . 
            if (scoreList.Count > 10)
            {
                Debug.Log(scoreList.Count);
                scoreList.RemoveAt(10);
            }

            //8. 현재 점수가 추가된 리스트를 string으로 변환 후 저장한다 .
            string result = string.Join(",", scoreList);
            PlayerPrefs.SetString("HighScores", result);
            PlayerPrefs.SetString("MyScore", currentScoreString);
            PlayerPrefs.Save();

        }

    }

    private IEnumerator PauseGame()
    {
        yield return null; // 한 프레임 대기 
        Time.timeScale = 0;
    }

    public void RankPressed()
    {
        RankPopup.SetActive(true);
    }

    //public void PlayAgainPressed()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
