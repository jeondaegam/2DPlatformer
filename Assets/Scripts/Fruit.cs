using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float timeAdd = 5f;

    public TextMeshPro floatingPointPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddTime(timeAdd);
            GetComponent<Animator>().SetTrigger("Eaten");

            // floating text animation
            // y position이 0으로 고정되서 생성되는것같아서 parent를 transform으로설정
            TextMeshPro floatingPoint = Instantiate(floatingPointPrefab,transform);
            floatingPoint.text = $"+{timeAdd}";
            //floatingText.enabled = true;

            // 애니메이션이 끝난 시점인 0.6초 후 Destroy
            // Invoke("DestroyThis", .3f);
            Invoke("DestroyThis", 0.6f);
        }
    }

    private void DestroyThis()
    {
        // 
        Destroy(gameObject);
    }
}
