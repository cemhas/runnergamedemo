using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject woodPrefab;
    public GameObject coinPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.z < 150)
        {
            WoodSpawn();
            CoinSpawn();

        }

    }

    void WoodSpawn()
    {
        int rand_number = Random.Range(0, 100);

        if(rand_number == 1)
        {
            GameObject woodObj = Instantiate(woodPrefab,
            new Vector3(Random.Range(gameObject.transform.position.x * -0.9f, gameObject.transform.position.x * 0.9f),
            0f,
            (Random.Range(gameObject.transform.position.z * 0.9f, gameObject.transform.position.z * 1.7f))),
            Quaternion.Euler(0f, 0f, 0));


        }

    }

    void CoinSpawn()
    {
        int rand_number = Random.Range(0, 200);

        if (rand_number == 1)
        {
            GameObject woodObj = Instantiate(coinPrefab,
            new Vector3(Random.Range(gameObject.transform.position.x * -0.9f, gameObject.transform.position.x * 0.9f),
            0.7f,
            (Random.Range(gameObject.transform.position.z * 0.9f, gameObject.transform.position.z * 1.7f))),
            Quaternion.Euler(0f, 0f, 0));


        }

    }
}
