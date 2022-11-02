using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    EnemyHealth enemyHealth;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Kill_all")
        {
            KillAll();
        }
        else if (other.tag == "Bullet_upgrade")
        {
            Manager.AddDamage();
        }
    }

    public void KillAll()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyHealth = go.GetComponent<EnemyHealth>();
            print(go);
            enemyHealth.TakeDamage(1000);
        }
    }
}
