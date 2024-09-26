using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBackground : MonoBehaviour
{
    public float speed = 5f;
    public float size;

    // 이 때 첫번째 이미지의 x position을 0으로 맞춰주는게 중요
    // 예를들어 첫 이미지의 x position이 1일 경우 1만큼 공백 뒤에 다음 이미지가 생성되므로 계산이 필요하다 ~ 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -size)
        {
            transform.Translate(new Vector2(size * 2, 0));
        }
    }
}
