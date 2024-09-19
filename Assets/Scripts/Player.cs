using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public float jumpSpeed = 15f;
    private Vector2 originPosition;


    private float velocityX; // X축 방향 
    private float prevVx; // 이전 속도 


    public Collider2D bottomCollider;
    public CompositeCollider2D terrainCollider;
    private bool isGrounded;

    public GameObject bulletPrefab;
    private float lastShoot; // 마지막 슈팅 시간 
    private float coolTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        velocityX = 0;
        prevVx = 0;
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향키 입력받기 (velocityX = -1 or +1) 
        velocityX = Input.GetAxisRaw("Horizontal");


        // 캐릭터 좌우 방향 체크 
        if (velocityX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (velocityX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        // 0일때는 아무런 액션을 취하지 않고 이전 방향을 보고 있는다 . 


        // 2. 땅에 있는지 체크
        if (bottomCollider.IsTouching(terrainCollider))
        {
            if (!isGrounded)
            {
                if (velocityX == 0)
                {
                    GetComponent<Animator>().SetTrigger("Idle");
                }
                else
                {
                    GetComponent<Animator>().SetTrigger("Run");
                }
            }
            else
            {
                // 계속 걷는 중 
                if (prevVx != velocityX)
                {
                    if (velocityX == 0)
                    {
                        GetComponent<Animator>().SetTrigger("Idle");
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Run");
                    }
                }
            }
            isGrounded = true;
        }
        else // 땅에 붙어있지 않는 경우 
        {
            // 전에는 붙어 있었다면 ?
            if (isGrounded)
            {
                // 점프 
                GetComponent<Animator>().SetTrigger("Jump");
            }
            isGrounded = false;
        }


        // 제자리에 서있을 때 Idle 모션 
        //if (isGrounded && velocityX == 0)
        //{
        //    GetComponent<Animator>().SetTrigger("Idle");
        //    Debug.Log("Idle");
        //}
        //// Run: 달리는중 
        //else if (isGrounded && velocityX !=0)
        //{
        //    GetComponent<Animator>().SetTrigger("Run");
        //    Debug.Log("Run");
        //}

        // 3. 땅에 있는 경우만 점프 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;

            // Jump 모션 
            //GetComponent<Animator>().SetTrigger("Jump");
            //Debug.Log("Jump");
        }

        // 총알 슈팅 
        if (Input.GetButtonDown("Fire1") && Time.time > (lastShoot + coolTime))
        {
            Vector2 bulletVelocity = Vector2.zero;

            if (GetComponent<SpriteRenderer>().flipX)
            {
                // 왼쪽으로 
                bulletVelocity = new Vector2(-10, 0);
            }
            else
            {
                // 오른쪽으로 
                bulletVelocity = new Vector2(10, 0);
            }

            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().velocity = bulletVelocity;
            lastShoot = Time.time;
        }

        prevVx = velocityX;
        

    }

    private void FixedUpdate()
    {
        // 이동(이동거리) = (오른쪽 * 방향(-1,+1) * 속도 * 시간)
        transform.Translate(Vector2.right * velocityX * speed * Time.fixedDeltaTime);
    }

    internal void Restart()
    {
        transform.position = originPosition;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }



    // 1. 캐릭터의 발(bottom) 부분에 캡슐 콜라이더 추가
    // 1-1. IsTrigger 체크 
    // 2. Terrain의 콜라이더와 Bottom 콜라이더를 레퍼런싱
    // 3. collider.IsToucing : true / false
    // 4. true 일 때만 점프 가능하도록


}
