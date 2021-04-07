using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public bool woodCollected;

    public float woodNumber;

    public GameObject woodPrefab;
    public GameObject newWoodObject;

    public GameObject[] collectedWoods;

    private Animator playerAnim;

    [HideInInspector]
    public int coinAmount;

    public GameObject levelFailed;

    public PlayerController pc;



    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
        woodNumber = 0;
        playerAnim = gameObject.GetComponent<Animator>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        collectedWoods = GameObject.FindGameObjectsWithTag("WoodCollected");
        for (int i = 0; i < collectedWoods.Length; i++)
        {
            collectedWoods[i].transform.position = newWoodObject.transform.position + new Vector3(0f, i *0.5f, 0f);
            gameObject.transform.position += new Vector3(0f, 0.5f, 0f);

        }

        if(collectedWoods.Length == 0)
        {
            if(pc.endGame != true)
            {
                levelFailed.gameObject.SetActive(true);
                playerAnim.SetBool("IsRunning", true);
                playerAnim.SetBool("IsSurfing", false);
            } else if (pc.endGame == true)
            {
                playerAnim.SetBool("IsRunning", false);
                playerAnim.SetBool("IsFalling", true);
            }
            

        }
        if(collectedWoods.Length>0)
        {
            levelFailed.gameObject.SetActive(false);
            playerAnim.SetBool("IsRunning", false);
            playerAnim.SetBool("IsSurfing", true);
        }


    }

    private void OnTriggerExit(Collider target)
    {
        if (target.gameObject.tag == "Wood")
        {
            woodCollected = true;

            Destroy(target.gameObject);
            AddNewWoods();


        }


    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.gameObject.tag == "Coin")
        {
            coinAmount = coinAmount + 10;
            Destroy(target.gameObject);
        }

    
    }





    void AddNewWoods()
    {
        if (woodCollected)
        {

            woodCollected = false;

            GameObject newWood = Instantiate(woodPrefab, newWoodObject.transform.position, Quaternion.identity);
            newWood.transform.SetParent(newWoodObject.transform, true);

            woodNumber = woodNumber + 0.5f;



        }


    }

    void RepositionWoods()
    {
        collectedWoods[0].transform.position = new Vector3(collectedWoods[0].transform.position.x, 0f, collectedWoods[0].transform.position.z);

    }



}
