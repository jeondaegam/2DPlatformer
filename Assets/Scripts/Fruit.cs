using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float timeAdd = 5f;

    public TextMeshPro floatingPointPrefab;

    public AudioClip itemCollectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 점수 증가 
            GameManager.Instance.AddTime(timeAdd);
            // 애니메이션 시작 
            GetComponent<Animator>().SetTrigger("Eaten");
            // 사운드 
            AudioManager.Instance.PlayeSound(itemCollectSound);

            // 점수 보여주기 - 텍스트 팝업 애니메이션 
            // y position이 0으로 고정되서 생성되는것같아서 parent를 transform으로설정
            TextMeshPro floatingPoint = Instantiate(floatingPointPrefab,transform);
            floatingPoint.text = $"+{timeAdd}";
            
            //floatingPoint.enabled = true;
            // 애니메이션이 끝난 시점인 0.6초 후 Destroy
            // Invoke("DestroyThis", .3f);
            Invoke("DestroyThis", 0.5f);
        }
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
