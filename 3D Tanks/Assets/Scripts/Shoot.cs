using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    public GameObject bullet;
    public float speed = 30;
    public PlayerMovement playerMovementScript;
    public Transform firePoint;
    public float shootDelay;
    public float timeBetweemShoots;

    
    private void Update()
    {

        if (!Manager.gamePaused)
        {
            shootDelay -= Time.deltaTime;
            
            if (shootDelay <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GameObject instBullet = Instantiate(bullet, firePoint.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                    if (playerMovementScript.isFacingDown)
                    {
                        instBulletRB.AddForce(-Vector3.forward * speed * Time.deltaTime);
                    }
                    else if (playerMovementScript.isFacingUp)
                    {
                        instBulletRB.AddForce(Vector3.forward * speed * Time.deltaTime);
                    }
                    else if (playerMovementScript.isFacingRight)
                    {
                        instBulletRB.AddForce(Vector3.right * speed * Time.deltaTime);
                    }
                    else if (playerMovementScript.isFacingLeft)
                    {
                        instBulletRB.AddForce(Vector3.left * speed * Time.deltaTime);
                    }
                    shootDelay = timeBetweemShoots;

                }
            }
        }
        
        
    }


}
