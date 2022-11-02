using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObsticles : MonoBehaviour
{
    int hits;
    private void Start()
    {
        hits = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyProjectile" || other.tag == "PlayerProjectile")
        {
            hits++;
            if(hits >= 5)
            {
                Destroy(gameObject);
            }
        }
    }
}
