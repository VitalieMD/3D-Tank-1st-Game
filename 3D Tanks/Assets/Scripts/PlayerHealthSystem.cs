using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    EnemyProjectile enemyProjectile;
    HealthBar healthBar;                              //HealthBar Script
    public int lives;                                 //how many lives player have

    public float currentHealth;                       //current health of the player
    public float maxHealth;                           //max health of the player

    public float protectionTime;                      // Shield time
    public bool isProtected = false;                  //If player pickup shield value is true
    public GameObject shieldLayer, fireEffect, smokeEffect, explosionEffect;


    Transform playerRespawnLoc;                       //Player respawn location

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        smokeEffect.SetActive(false);
        fireEffect.SetActive(false);
        explosionEffect.SetActive(false);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        IsProtected();
        playerRespawnLoc = GameObject.FindGameObjectWithTag("PlayerRespawnLocation").transform;
        SetEffects();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
        {
            GetComponent<PlayerMovement>().enabled = false;
            explosionEffect.SetActive(true);
            Invoke("PlayerDie",2f);
            Manager.AddLives(-1);
        }
    }

    void SetEffects()
    {
        if(currentHealth <= 50 && currentHealth > 25){
            smokeEffect.SetActive(true);
        }
        else if(currentHealth <= 25){
            fireEffect.SetActive(true);
        }
        else if(currentHealth > 50){
        smokeEffect.SetActive(false);
        fireEffect.SetActive(false);
        }
    }
    public void AddLifePoints()
    {
        if(currentHealth <= 75)
        {
            currentHealth += 5;
            healthBar.SetHealth(currentHealth);
        }
    }

    void PlayerDie()
    {
        smokeEffect.SetActive(false);
        fireEffect.SetActive(false);
        gameObject.SetActive(false);
        gameObject.transform.position = playerRespawnLoc.transform.position;
        currentHealth = 80;
        healthBar.SetMaxHealth(maxHealth);
        gameObject.SetActive(true);
        Manager.bulletUpgrades = 0;
        Manager.damage = 20;
        GetComponent<PlayerMovement>().enabled = true;
        explosionEffect.SetActive(false);
    }
    void IsProtected()  //When player pickup shield
    {
        if (isProtected)
        {
            shieldLayer.SetActive(true);
            protectionTime += Time.deltaTime;
            if (protectionTime >= 15)
            {
                protectionTime = 0;
                isProtected = false;
                shieldLayer.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyProjectile") //if enemy's projectiles touch player
        {
            enemyProjectile = other.GetComponent<EnemyProjectile>();
            if (!isProtected)
            {
                TakeDamage(enemyProjectile.damage);
            }
            
        }
        else if(other.tag == "Shield") //if player trigger Shield
        {
            isProtected = true;
        }
        else if (other.tag == "Add_life")
        {
            Manager.AddLives(1);
        }

    }
}
