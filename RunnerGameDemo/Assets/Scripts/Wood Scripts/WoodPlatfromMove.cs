using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlatfromMove : MonoBehaviour
{
    private float moveSpeedZ = 5f;
    private float moveForce = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WoodMove();
    }

    void WoodMove()
    {
        transform.position += new Vector3(0f, 0f, moveSpeedZ * Time.deltaTime * moveForce);
    }
}
