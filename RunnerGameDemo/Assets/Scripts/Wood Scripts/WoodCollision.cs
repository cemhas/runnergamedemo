using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollision : MonoBehaviour
{
    public PlayerCollision pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);

            pc.woodNumber--;
        }
    }
}
