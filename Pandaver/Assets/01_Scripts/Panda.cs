using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    PandaSpawner spawner;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        spawner = transform.parent.parent.GetComponent<PandaSpawner>(); // 할머니 찾기
    }

    private void Start()
    {
        rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
    }

    private void Update()
    {
        if (transform.position.y < -2)
        {
            spawner.RealPandas.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
