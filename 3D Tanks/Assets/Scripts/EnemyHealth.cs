using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public GameObject[] loot;
    [SerializeField] public Transform lootPos;
    [SerializeField] float currentHealth;
    InstantiateEnemys instantiateEnemysScript;
    public GameObject fireEffectEnemy;
    public GameObject smokeEffectEnemy;


    private void Awake()
    {
        currentHealth = health;
        instantiateEnemysScript = FindObjectOfType<InstantiateEnemys>();
        smokeEffectEnemy.SetActive(false);
        fireEffectEnemy.SetActive(false);
    }

    void Update(){
         SetEffectsEnemy();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            Instantiate(loot[Random.Range(0, loot.Length)], gameObject.transform.position + new Vector3(0.0f, 3.0f, 0.0f), Quaternion.Euler(0f, 0f, 0f));
            Manager.totalEnemysDestroyed++;
            Manager.score += 50;
            instantiateEnemysScript.enemysDestroyed++;
            Destroy(gameObject);
            
        }
    }
    void SetEffectsEnemy()
    {
        if(currentHealth <= 50 && currentHealth > 30){
            smokeEffectEnemy.SetActive(true);
        }
        else if(currentHealth <= 30){
            fireEffectEnemy.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerProjectile")
        {
            TakeDamage(Manager.damage);
        }
    }
}
