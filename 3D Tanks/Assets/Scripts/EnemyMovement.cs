using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = .00003f;
    public float timeToChangeDir;
    [SerializeField] int i;
    [SerializeField] int maxDistFromWall;
    public LayerMask whatIsObsticle;
    Rigidbody rb;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        GenerateRandomI();
        InvokeRepeating("GenerateRandomI", 2, 2);
    }
    private void Update()
    {
        ReturnI();
        ChooseDirection();
        Debug.DrawRay(transform.position + new Vector3(0f, 1f, 0f), transform.forward * 7, Color.red);
        Physics.Raycast(transform.position, transform.forward);
        if (Physics.Raycast(transform.position + new Vector3(0f, 1f, 0f), transform.forward, maxDistFromWall, whatIsObsticle ))
        {
            if (i==0)
            {
                i=1;
            }
            else if (i==1)
            {
                i = 0;
            }
            else if (i == 2)
            {
                i = 3;
            }
            else if (i == 3)
            {
                i = 2;
            }

        }

    }
    public int ReturnI()
    {
        return i;
    }
    
    void GenerateRandomI()
    {
        i = Random.Range(0, 4);
    }
    void ChooseDirection()
    {
        if (i == 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (i == 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (i == 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (i == 3)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
    }

}
