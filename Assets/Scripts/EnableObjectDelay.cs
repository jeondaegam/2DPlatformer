using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectDelay : MonoBehaviour
{
    //public GameObject obj;
    public float enableDelaySeconds;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("EnableObject", enableDelaySeconds);
    }

    void EnableObject()
    {
        gameObject.SetActive(true);
    }
}
