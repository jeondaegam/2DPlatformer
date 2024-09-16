using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit = 30f;
    public TextMeshProUGUI scoreLabel;

    private int lives = 3;
    public GameObject virtualCamera;
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        scoreLabel.text = timeLimit.ToString("#.##");
    }

    public void StageClear()
    {
        Debug.Log($"Score: " + timeLimit);
        Debug.Log("Stage Clear");

    }

    internal void AddTime(float time)
    {
        timeLimit += time;
        // TODO 애니메이션 +n 
    }

    internal void Die()
    {
        // 카메라 무빙 중지 
        virtualCamera.SetActive(false);
        lives--;

        // 죽은 후 애니메이션 등 처리를 위해 2초의 텀을 두고 함수 호출 
        Invoke("CheckPlayerLives", 2f);
        Debug.Log("Die");
    }

    private void CheckPlayerLives()
    {
        if(lives <= 0)
        {
            GameOver();
        } else
        {
            virtualCamera.SetActive(true);
            player.Restart();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
