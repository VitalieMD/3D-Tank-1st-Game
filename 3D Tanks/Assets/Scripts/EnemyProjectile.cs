using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifeTime;
    public float damage;


    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

    }
}
