using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleRotation : MonoBehaviour
{
    Quaternion rotation;
    float z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Quaternion.Euler(0,0,z);
        transform.rotation = rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            z = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            z = 180;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            z = 270;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            z = 90;
        }
    }
}
