using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotator : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
            
    }
}
