using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

    public Text pressEnterLabel;
    public string typingText = "Press <Enter> to play";

    // Start is called before the first frame update
    void Start()
    {
        pressEnterLabel.text = "";
        pressEnterLabel.DOText(typingText, 2f).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
