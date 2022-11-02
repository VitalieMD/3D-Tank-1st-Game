using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isFacingDown;
    public bool isFacingRight;
    public bool isFacingLeft;
    public bool isFacingUp;
    public bool boosting;
    [SerializeField] private float boosterTime;

    Rigidbody rb;

    private void Start()
    {
        boosting = false;
        rb = gameObject.GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        MovePlayer();
        SpeedBoost();
    }
    void SpeedBoost()
    {
        if (boosting)
        {
            moveSpeed = 1100f;
            boosterTime += Time.deltaTime;
            if (boosterTime >= 30)
            {
                moveSpeed = 800f;
                boosterTime = 0;
                boosting = false;
            }
        }
    }

    void MovePlayer()
    {

        if (Input.GetKey(KeyCode.A))
        {
            isFacingLeft = true;
            isFacingRight = false;
            isFacingUp = false;
            isFacingDown = false;
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            isFacingLeft = false;
            isFacingUp = false;
            isFacingDown = false;
            isFacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
        }

        else if  (Input.GetKey(KeyCode.W))
        {
            isFacingLeft = false;
            isFacingRight = false;
            isFacingUp = true; ;
            isFacingDown = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
        }
        else if  (Input.GetKey(KeyCode.S))
        {
            isFacingLeft = false;
            isFacingRight = false;
            isFacingUp = false;
            isFacingDown = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Speed_boost")
        {
            boosting = true;
            Destroy(other.gameObject);
        }
    }

}
