using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity = new Vector2(10, 0);
    public int damage = 1;


    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain"))
        {
            gameObject.SetActive(false);
        } else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().Hit(damage);
            gameObject.SetActive(false);
        }
    }
}
