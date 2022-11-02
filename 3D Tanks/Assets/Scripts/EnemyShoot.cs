using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed = 100;
    public EnemyMovement enemyMovement;
    public Transform firePoint;
    public float timeBetweemShoot;
    public float shootDelay;
    private void FixedUpdate()
    {
        shootDelay -= Time.deltaTime;
        if (shootDelay<=0)
        {
            
            if (enemyMovement.ReturnI() == 0)
            {
                GameObject instBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 270, 0)) as GameObject;
                Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                instBulletRB.AddForce(Vector3.left * speed * Time.deltaTime);
            }
            else if (enemyMovement.ReturnI() == 1)
            {
                GameObject instBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 90, 0)) as GameObject;
                Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                instBulletRB.AddForce(Vector3.right * speed * Time.deltaTime);
            }
            else if (enemyMovement.ReturnI() == 2)
            {
                GameObject instBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                instBulletRB.AddForce(Vector3.forward * speed * Time.deltaTime);
            }
            else if (enemyMovement.ReturnI() == 3)
            {
                GameObject instBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(0, 180, 0)) as GameObject;
                Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
                instBulletRB.AddForce(-Vector3.forward * speed * Time.deltaTime);
            }
            shootDelay = timeBetweemShoot;

        }
    }
}
