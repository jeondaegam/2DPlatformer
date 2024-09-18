using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    public TextMeshProUGUI titleLabel;
    public TextMeshProUGUI scoreLabel;

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
        }
        else
        {
            Time.timeScale = 0;
            titleLabel.text = "GAME OVER";
            scoreLabel.text = "";
        }

        //StartCoroutine(PauseGame());
    }

    private IEnumerator PauseGame()
    {
        yield return null; // 한 프레임 대기 
        Time.timeScale = 0;
    }

    //public void PlayAgainPressed()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
