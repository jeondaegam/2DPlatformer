using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public float jumpSpeed = 15f;
    private float velocityX; // X축 방향 


    
    public Collider2D bottomCollider;
    public CompositeCollider2D terrainCollider;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향키 입력받기 (velocityX = -1 or +1) 
        velocityX = Input.GetAxisRaw("Horizontal");

        // 2. 땅에 있는지 체크
        isGrounded = bottomCollider.IsTouching(terrainCollider);

        // 3. 땅에 있는 경우만 점프 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
        }

    }

    private void FixedUpdate()
    {
        // 이동(이동거리) = (오른쪽 * 방향(-1,+1) * 속도 * 시간)
        transform.Translate(Vector2.right * velocityX * speed * Time.fixedDeltaTime);
    }



    // 1. 캐릭터의 발(bottom) 부분에 캡슐 콜라이더 추가
    // 1-1. IsTrigger 체크 
    // 2. Terrain의 콜라이더와 Bottom 콜라이더를 레퍼런싱
    // 3. collider.IsToucing : true / false
    // 4. true 일 때만 점프 가능하도록
    

}
