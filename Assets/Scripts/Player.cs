using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 7f;
    private float velocityX; // X축 방향 

    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // velocityX = -1 or +1 
        velocityX = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // 이동(이동거리) = (오른쪽 * 방향(-1,+1) * 속도 * 시간)
        transform.Translate(Vector2.right * velocityX * speed * Time.fixedDeltaTime);
    }
}
