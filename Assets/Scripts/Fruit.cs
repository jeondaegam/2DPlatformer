using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float timeAdd = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddTime(timeAdd);
            GetComponent<Animator>().SetTrigger("Eaten");

            // 애니메이션이 끝난 시점인 0.3초 후 Destroy
            Invoke("DestroyThis", 0.3f);
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
