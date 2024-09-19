using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    // 인스턴싱할 프리팹 원본
    public GameObject bulletPrefab;

    // 인스턴싱할 개수
    public List<GameObject> bullets;

    public int bulletLimit = 30;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();

        // bullet 인스턴스 리스트 생성 
        for (int i = 0; i < bulletLimit; i++)
        {
            // parent : transform, ObjectPool을 부모 오브젝트로 설정
            GameObject go = Instantiate(bulletPrefab, transform); 
            go.SetActive(false);
            bullets.Add(go);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeSelf)
            {
                bullet.SetActive(true);
                return bullet;
            }

        }
        // 만약 리턴할 총알이 없는 경우 새로 생성
        GameObject newBullet = Instantiate(bulletPrefab, transform);
        newBullet.SetActive(true);
        bullets.Add(newBullet);
        return newBullet;
    }


}
