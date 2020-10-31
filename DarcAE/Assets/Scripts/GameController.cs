using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public int totalVidas;
    public Text scoreText;
    public Text textVidas;

    public GameObject gameOver;
    public GameObject nextLvl;

    //para outro script poder acessar essa classe
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateTextVidas();
    }

    public void UpdateScoreText()
    {
        //ToString tranforma o valor em text
        scoreText.text = totalScore.ToString();
    }
    public void UpdateTextVidas()
    {
        textVidas.text = totalVidas.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGamer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvl()
    {
        if(totalScore == 16)
        {
            nextLvl.SetActive(true);
        }else
        {
            ShowGameOver();
        }
        
    }
}
