using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveForce = 0.1f;
    private Vector3 lastPosition;
    private Vector3 moveDirection;
    private float moveSpeedZ = 7f;

    public bool endGame;

    public GameObject newWoodObject;
    
    private Animator playerAnim;

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        endGame = false;

        playerAnim = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.transform.position.z < 230f)
        {
            PlayerConstantMove();
            PlayerInput();
        }
        else
        {
            EndGame();
        }

        FallOfPlayer();

    }


    public void PlayerInput()
    {
        moveForce = 0.1f;
        if (Input.GetMouseButtonDown(0))
        {

            lastPosition.x = Input.mousePosition.x;

        }
        else if (Input.GetMouseButton(0))
        {
            
            
            moveDirection = new Vector3((Input.mousePosition.x - lastPosition.x), 0, 0);
            
            PlayerHorizontalMove();

        }

    }

    private void PlayerConstantMove()
    {
        transform.position += new Vector3(0f, 0f, moveSpeedZ) * Time.deltaTime;
    }


    private void PlayerHorizontalMove()
    {
        transform.position += moveDirection * Time.deltaTime * moveForce;

    }

    public void EndGame()
    {
        playerAnim.SetBool("IsRunning", false);
        playerAnim.SetBool("IsSurfing", false);


        gm.RestartGame();
        endGame = true;
    }

    public void LevelFailed()
    {
        playerAnim.SetBool("IsFalling", true);
        playerAnim.SetBool("IsRunning", false);
        playerAnim.SetBool("IsSurfing", false);
        endGame = true;
        Invoke("EndGame", 1f);

    }

    void FallOfPlayer()
    {
        if (endGame)
        {

            //Oyun sonu geldiğinde oyuncunun serbest düşme hareketini bu kısımda kodlayacaktım ancak oyuncunun altında oluşan küpleri "Iskinematic" yaptığım ve "Use Gravity" kısmı tikli olmadığı için
            //fizik motorunu kullanarak o düşüş anını canlandıramadım, Sonrasında bu objelerin hepsini serbest düşmeyi yansıtabilmek adına rotate etmek istedim ancak onda
            // da istediğim gibi olmadı, rotate etmek ile ilgili bazı kodlar aşağıda mevcut
            // 
            

            /*gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(90f, 0f, 0f), 1f * Time.deltaTime);

            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;

            newWoodObject.transform.rotation = Quaternion.Slerp(newWoodObject.transform.rotation, Quaternion.Euler(90f, 0f, 0f), 1f * Time.deltaTime);

            newWoodObject.transform.rotation = Quaternion.Euler(180f, 0f, 0f);*/

        }
  

    }

    


}
