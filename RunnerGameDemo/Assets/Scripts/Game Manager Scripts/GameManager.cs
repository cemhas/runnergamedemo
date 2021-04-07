using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text coinText;
    public PlayerCollision pc;
    public GameObject pausePanel;
    public GameObject restartPanel;


    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = pc.coinAmount.ToString();
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 0f;
        restartPanel.SetActive(true);

    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        restartPanel.SetActive(false);
        SceneManager.LoadScene("Gameplay");
    }

    

    
}
