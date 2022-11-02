using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    public EnemyHealth enemyHealthScript;
    

    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
