using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    public Vector3 offsetPosition;
    public Vector3 rotationAngle;

    public PlayerCollision pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SettingAngles();
        FollowPlayer();
    }

    void FollowPlayer()
    {

        transform.position = target.position + offsetPosition;
        transform.rotation = Quaternion.Euler(rotationAngle);

    }

    void SettingAngles()
    {
        if (pc.collectedWoods.Length <= 5)
        {
            offsetPosition = new Vector3(0f, 5f, -10f);
            rotationAngle = new Vector3(10f, 0f, 0f);
        }

        else if (pc.collectedWoods.Length > 5 && pc.collectedWoods.Length <= 10)
        {
            offsetPosition = new Vector3(2f, 6f, -13f);
            rotationAngle = new Vector3(12f, -3f, 0f);
        }
        else if (pc.collectedWoods.Length > 10 && pc.collectedWoods.Length <= 12)
        {
            offsetPosition = new Vector3(3f, 6f, -15f);
            rotationAngle = new Vector3(15f, -5f, 0f);
        }
        else if (pc.collectedWoods.Length > 12 && pc.collectedWoods.Length <= 15)
        {
            offsetPosition = new Vector3(5f, 10f, -18f);
            rotationAngle = new Vector3(20f, -8f, 0f);
        }
        else if (pc.collectedWoods.Length > 15 && pc.collectedWoods.Length <= 18)
        {
            offsetPosition = new Vector3(6f, 12f, -19f);
            rotationAngle = new Vector3(23f, -10f, 0f);
        }
        else
        {
            offsetPosition = new Vector3(6f, 12f, -20f);
            rotationAngle = new Vector3(25f, -13f, 0f);
        }


    }
}
