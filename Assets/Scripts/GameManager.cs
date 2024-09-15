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
}
