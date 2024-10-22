using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleObjectAnimation : MonoBehaviour
{
    public GameObject pressEnter;
    public GameObject gameByYeoreum;
    public GameObject title;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimationSequentially());
    }

    private IEnumerator PlayAnimationSequentially()
    {
        yield return new WaitForSeconds(1.5f);
        title.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameByYeoreum.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        pressEnter.SetActive(true);
    }
}
