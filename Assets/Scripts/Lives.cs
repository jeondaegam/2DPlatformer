using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> lifeImages;

    public void SetLives(int life)
    {
        // 처음에는 모두 꺼준다. 
        foreach(GameObject img in lifeImages)
        {
            img.SetActive(false);
        }

        // 다시 세팅한다
        for(int i=0; i<life; i++)
        {
            lifeImages[i].SetActive(true);
        }
    }

}
