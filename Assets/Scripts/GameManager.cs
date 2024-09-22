using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit { get; private set; } = 30f;
    public TextMeshProUGUI scoreLabel;

    public GameObject virtualCamera;
    public Player player;

    private int lives = 3;
    public Lives lifeDisplayer;
    public GameObject resultPopup;
    public bool isCleared;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isCleared = false;
        lifeDisplayer.SetLives(lives);
        //InitScores();
    }

    private void InitScores()
    {
        PlayerPrefs.SetString("HighScores", "");
        PlayerPrefs.Save();
        Debug.Log("Init Scores OK ");
        Debug.Log($"Scores :{PlayerPrefs.GetString("HighScores", "")}");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCleared)
        {
        timeLimit -= Time.deltaTime;
        scoreLabel.text = timeLimit.ToString("00.00");

        }
    }


    internal void AddTime(float time)
    {
        timeLimit += time;
        // TODO 애니메이션
    }

    internal void Die()
    {
        lives--;

        // 카메라 무빙 중지 
        virtualCamera.SetActive(false);

        // 생명 UI 수정
        lifeDisplayer.SetLives(lives);

        // 죽은 후 애니메이션 등 처리를 위해 2초의 텀을 두고 함수 호출 
        Invoke("CheckPlayerLives", 1f);
    }

    private void CheckPlayerLives()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            virtualCamera.SetActive(true);
            player.Restart();
        }
    }

    public void StageClear()
    {
        isCleared = true;
        resultPopup.SetActive(true);
    }

    private void GameOver()
    {
        isCleared = false;
        resultPopup.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
