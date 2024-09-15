using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Trigger가 세팅된 collider에 다른 오브젝트가 들어왔을 때 발생하는 이벤트 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.StageClear();
        }
    }
}
