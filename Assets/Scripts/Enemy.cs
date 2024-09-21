using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // 이동 속도 
    public float speed = 3f;
    // 현재 이동 상태
    public Vector2 vx;

    public int HP = 3;

    // 장애물, 절벽 인식
    public Collider2D frontBottomCollider;
    public Collider2D frontCollider;

    // 땅 인식을 위한 Tilemap의 콜라이더 
    public CompositeCollider2D terrainCollider;


    // Start is called before the first frame update
    void Start()
    {
        vx = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // 장애물 혹은 절벽을 만나면 
        if (frontCollider.IsTouching(terrainCollider)
            ||!frontBottomCollider.IsTouching(terrainCollider))
        {
            // 반대 방향으로 전환 
            vx = -vx;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(vx * Time.fixedDeltaTime);
    }

    public void Hit(int damage)
    {
        HP -= damage;
        Debug.Log($" Hit! Enemy's damage : {HP}");
        if (HP <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        // 두바퀴 회전, 콩 튀면서, 떨어지고, 2초뒤 사라지기
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().angularVelocity = 720;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
